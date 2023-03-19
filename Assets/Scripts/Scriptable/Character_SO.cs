using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Character_SO")]
public class Character_SO : ScriptableObject
{
    [SerializeField] GameObject startingWeapon;
    public GameObject StartingWeapon { get { return startingWeapon; } private set { startingWeapon = value; } }

    [SerializeField] float maxHealth;
    public float MaxHealth { get { return maxHealth; } private set { maxHealth = value; } }

    [SerializeField] float recovery;
    public float Recovery { get { return recovery; } private set { maxHealth = value; } }

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } private set { moveSpeed = value; } }

    [SerializeField] float magnet;
    public float Magnet { get { return magnet; } private set { magnet = value; } }
}
