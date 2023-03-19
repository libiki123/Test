using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [System.Serializable]
    public class Drop
    {
        public DropType type;
        public float droprate;
    }

    [SerializeField] private List<Drop> drops = new List<Drop>();

    public void DropItem()
    {
        float randomNum = Random.Range(0f, 100f);

        foreach (Drop drop in drops)
        {
            if(randomNum <= drop.droprate)
            {
                GameObject tempObj = ObjectsPool.instance.GetDrop(drop.type);
                tempObj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                tempObj.SetActive(true);
                break;
            }
        }
    }
}
