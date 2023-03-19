using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/Weapon_SO")]
public class Weapon_SO : ScriptableObject
{
    [SerializeField] ProjectileType projectileType;
    public ProjectileType ProjectileType { get { return projectileType; } private set { projectileType = value; } }

    [SerializeField] float damage;
    public float Damage { get { return damage; } private set { damage = value; } }

    [SerializeField] float projectileSpeed;
    public float ProjectileSpeed { get { return projectileSpeed; } private set { projectileSpeed = value; } }

    [SerializeField] float cooldownDuration;
    public float CooldownDuration { get { return cooldownDuration; } private set { cooldownDuration = value; } }

    [SerializeField] int pierce;
    public int Pierce { get { return pierce; } private set { pierce = value; } }

    [SerializeField] int numberOfProjectiles;
    public int NumberOfProjectiles { get { return numberOfProjectiles; } private set { numberOfProjectiles = value; } }

    [SerializeField][Range(0, 360)] float maxAngle;
    public float MaxAngle { get { return maxAngle; } private set { maxAngle = value; } }
}
