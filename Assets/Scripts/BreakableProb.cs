using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DropManager))]
public class BreakableProb : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private DropManager dropManager;
    private float currentHealth;

    private void Start()
    {
        dropManager = GetComponent<DropManager>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if(currentHealth < 0)
        {
            Break();
        }
    }

    private void Break()
    {
        currentHealth = maxHealth;
        dropManager.DropItem();
        gameObject.SetActive(false);
    }
}
