using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private MeshRenderer meshRenderer2;
    List<Color> orginColor = new List<Color>();
    List<Color> orginColor2 = new List<Color>();
    Material[] mats;
    Material[] mats2;

    [Header("Flash Stats")]
    [SerializeField] float flashInterval = 0.15f;

    private void Start()
    {
        mats = meshRenderer.materials;        
        foreach(var mat in mats)
        {
            orginColor.Add(mat.color);
        }

        if (meshRenderer2 != null)
        {
            mats2 = meshRenderer2.materials;
            foreach (var mat in mats2)
            {
                orginColor2.Add(mat.color);
            }
        }
            
    }

    private void Update()
    {
     
    }

    public void FlashStart()
    {
        foreach (Material mat in mats)
        {
            mat.color =  Color.white;
        }
        meshRenderer.materials = mats;

        if(mats2 != null)
        {
            foreach (Material mat in mats2)
            {
                mat.color = Color.white;
            }
            meshRenderer2.materials = mats2;
        }
    }

    private void FlashStop()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].color = orginColor[i];
        }
        meshRenderer.materials = mats;

        if (mats2 != null)
        {
            for (int i = 0; i < mats2.Length; i++)
            {
                mats2[i].color = orginColor2[i];
            }
            meshRenderer2.materials = mats2;
        }
    }

    private IEnumerator DFlash()
    {
        int count = 3;

        while (count > 0)
        {
            Debug.Log(count);
            FlashStart();
            yield return new WaitForSeconds(5);
            FlashStop();
            count--;
        }

    }
}
