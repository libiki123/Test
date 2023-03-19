using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private List<Transform> propSpawnPoints = new List<Transform>();

    private void Start()
    {
        StartCoroutine(SpawnProps());
    }

    private IEnumerator SpawnProps()
    {
        while (true)
        {
            Debug.Log("Spawn Props");
            foreach (Transform sp in propSpawnPoints)
            {
                float rand = UnityEngine.Random.Range(0f, 100f);

                if (rand <= spawnRate)
                {

                    if (sp.childCount > 0)
                    {
                        if (!sp.GetChild(0).gameObject.activeInHierarchy)
                        {
                            sp.GetChild(0).gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        int random = UnityEngine.Random.Range(0, Enum.GetNames(typeof(PropType)).Length);
                        GameObject prop = ObjectsPool.instance.GetProp((PropType)random);
                        prop.transform.SetPositionAndRotation(sp.position, Quaternion.identity);
                        prop.transform.parent = sp;
                        prop.SetActive(true);
                    }
                }
            }

            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
