using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] protected Weapon_SO weaponData;
    [SerializeField] protected Transform bulletSpawnLocation;
    
    protected ProjectileType currentProjectileType;
    protected float currentCooldown;
    protected float currentnumberOfProjectile;
    protected float currentMaxAngle;

    virtual protected void Start()
    {
        currentProjectileType = weaponData.ProjectileType;
        currentCooldown = weaponData.CooldownDuration;
        currentnumberOfProjectile = weaponData.NumberOfProjectiles;
        currentMaxAngle = weaponData.MaxAngle;
    }

    virtual protected void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f)
        {
            Attack();
        }
    }

    virtual protected void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }
}
