using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/Enemy_SO")]
public class Enemy_SO : ScriptableObject
{
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } private set { moveSpeed = value; } }

    [SerializeField] float maxHealth;
    public float MaxHealth { get { return maxHealth; } private set { maxHealth = value; } }

    [SerializeField] float damage;
    public float Damage { get { return damage; } private set { damage = value; } }
}
