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

    float flashTime = 0.15f;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlashStart();
        }
    }

    public void FlashStart()
    {
        foreach (Material mat in mats)
        {
            mat.color =  Color.white;
        }
        meshRenderer.materials = mats;

        if(mats2.Length > 0)
        {
            foreach (Material mat in mats2)
            {
                mat.color = Color.white;
            }
            meshRenderer2.materials = mats2;
        }

        Invoke(nameof(FlashStop), flashTime);
    }

    private void FlashStop()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].color = orginColor[i];
        }

        meshRenderer.materials = mats;
    }
}
