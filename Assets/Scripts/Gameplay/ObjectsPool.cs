using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    public static ObjectsPool instance;

    [Header("Prop Prefabs")]
    [SerializeField] private GameObject cratePrefab;
    [SerializeField] private GameObject chestPrefab;

    private List<GameObject> crateList = new List<GameObject>();
    private List<GameObject> chestList = new List<GameObject>();

    [Header("Projectile Prefabs")]
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject fireBallPrefab;
    [SerializeField] private GameObject fireBall02Prefab;
    [SerializeField] private GameObject bouncerPrefab;

    private List<GameObject> arrowList = new List<GameObject>();
    private List<GameObject> fireBallList = new List<GameObject>();
    private List<GameObject> fireBall02List = new List<GameObject>();
    private List<GameObject> bouncerList = new List<GameObject>();

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private GameObject golemPrefab;

    private List<GameObject> ghostList = new List<GameObject>();
    private List<GameObject> golemList = new List<GameObject>();

    [Header("DropItem Prefabs")]
    [SerializeField] private GameObject blueExpPrefab;
    [SerializeField] private GameObject redHeartPrefab;

    private List<GameObject> blueExpList = new List<GameObject>();
    private List<GameObject> redHeartList = new List<GameObject>();


    private bool notEnoughObjectInPool = true;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    public GameObject GetProp(PropType type)
    {
        switch (type)
        {
            case PropType.CRATE:
                return GetPoolObject(crateList, cratePrefab);
                break;
            case PropType.CHEST:
                return GetPoolObject(chestList, chestPrefab);
                break;
            default:
                return null;
        }
    }

    public GameObject GetProjectile(ProjectileType type)
    {
        switch (type)
        {
            case ProjectileType.ARROW:
                return GetPoolObject(arrowList, arrowPrefab);
                break;
            case ProjectileType.FIREBALL:
                return GetPoolObject(fireBallList, fireBallPrefab);
                break;
            case ProjectileType.FIREBALL02:
                return GetPoolObject(fireBall02List, fireBall02Prefab);
                break;
            case ProjectileType.BOUNCER:
                return GetPoolObject(bouncerList, bouncerPrefab);
                break;
            default:
                return null;
        }
    }

    public GameObject GetEnemy(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.GHOST:
                return GetPoolObject(ghostList, ghostPrefab);
                break;
            case EnemyType.GOLEM:
                return GetPoolObject(golemList, golemPrefab);
                break;
            case EnemyType.SLIME:
                return null;
                break;
            default:
                return null;
        }
    }


    public GameObject GetDrop(DropType type)
    {
        switch (type)
        {
            case DropType.BLUE_EXP:
                return GetPoolObject(blueExpList, blueExpPrefab);
                break;
            case DropType.GREEN_EXP:
                return null;
                break;
            case DropType.RED_HEART:
                return GetPoolObject(redHeartList, redHeartPrefab);
                break;
            default:
                return null;
        }
    }

    public GameObject GetPoolObject(List<GameObject> list, GameObject prefab)
    {
        if (list.Count > 0)
        {
            foreach (GameObject gb in list)
            {
                if (!gb.activeInHierarchy)
                {
                    return gb;
                }
            }
        }

        if (notEnoughObjectInPool)
        {
            GameObject gb = Instantiate(prefab, transform);
            gb.SetActive(false);
            list.Add(gb);
            return gb;
        }

        return null;
    }
}

public enum PropType { CRATE, CHEST}
public enum ProjectileType { ARROW, FIREBALL, FIREBALL02, BOUNCER }
public enum DropType { BLUE_EXP, GREEN_EXP , RED_HEART }
public enum EnemyType { GHOST, GOLEM, SLIME }
