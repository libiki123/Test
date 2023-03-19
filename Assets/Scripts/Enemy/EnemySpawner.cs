using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance { get; private set; }

    [Header("Spawn Attribute")]
    [SerializeField] private float waveInterval;
    [SerializeField] private int maxEnemiesAllowed;

    [System.Serializable]
    public class EnemyGroup
    {
        public EnemyType enemyType;
        public int enemyCount;
        public int spawnCount;
    }

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups = new List<EnemyGroup>();
        public int numOfEnemyToSpawn; 
        public float spawnInterval; // time between each spawn
        public int spawnCount;
    }

    [Space]
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private List<Wave> waves = new List<Wave>();

    private int currentWaveIndex;
    private float spawnTimer;
    private int enemiesAlive;
    private bool maxEnemiesReached;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        CalculateWaveQuota();
    }

    private void Update()
    {
        //if(currentWaveIndex < waves.Count && waves[currentWaveIndex].spawnCount == 0)
        //{
        //    StartCoroutine(BeginNextWave());
        //}

        if(spawnTimer >= waves[currentWaveIndex].spawnInterval)
        {
            spawnTimer = 0;
            SpawnEnemies();
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
    }

    private void CalculateWaveQuota()
    {
        int TotalEnemy = 0;
        foreach (var enemyGroup in waves[currentWaveIndex].enemyGroups)
        {
            TotalEnemy += enemyGroup.enemyCount;
        }

        waves[currentWaveIndex].numOfEnemyToSpawn = TotalEnemy;
    }

    private void SpawnEnemies()
    {
        //if (waves[currentWaveIndex].spawnCount < waves[currentWaveIndex].numOfEnemyToSpawn && !maxEnemiesReached)
        //{
        //    foreach (var enemyGroup in waves[currentWaveIndex].enemyGroups)
        //    {
        //        if(enemyGroup.spawnCount < enemyGroup.enemyCount)
        //        {
        //            if(enemiesAlive >= maxEnemiesAllowed)
        //            {
        //                maxEnemiesReached = true;
        //                return;
        //            }


        //            int rand = Random.Range(0, spawnPoints.Count);
        //            GameObject tempEnemy = ObjectsPool.instance.GetEnemy(enemyGroup.enemyType);
        //            tempEnemy.transform.SetPositionAndRotation(spawnPoints[rand].position, Quaternion.identity);
        //            tempEnemy.SetActive(true);

        //            enemyGroup.spawnCount++;
        //            waves[currentWaveIndex].spawnCount++;
        //            enemiesAlive++;
        //        }
        //    }
        //}

        // USE THIS AS TEMPORARY TO MAKE GAME ENDLESS
        if (enemiesAlive >= maxEnemiesAllowed)
        {
            maxEnemiesReached = true;
            return;
        }
        
        if(!maxEnemiesReached)
        {
            int rand = Random.Range(0, spawnPoints.Count);
            int rand2 = Random.Range(0, 2);
            GameObject tempEnemy = ObjectsPool.instance.GetEnemy(rand2 == 0? EnemyType.GHOST : EnemyType.GOLEM);
            tempEnemy.transform.SetPositionAndRotation(spawnPoints[rand].position, Quaternion.identity);
            tempEnemy.SetActive(true);

            enemiesAlive++;
        }

        if (enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }

    private IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if(currentWaveIndex < waves.Count - 1)
        {
            currentWaveIndex++;
            CalculateWaveQuota();
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }
}
