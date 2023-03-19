using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DropManager))]
public class EnemyStats : MonoBehaviour
{
    [SerializeField] private Enemy_SO enemyData;
    
    [HideInInspector] public float currentMoveSpeed;
    private float currentHealth;
    private float currentDamage;
    private DropManager dropManager;

    private void Awake()
    {
        dropManager = GetComponent<DropManager>();
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        currentHealth = enemyData.MaxHealth;
        dropManager.DropItem();
        gameObject.SetActive(false);
        EnemySpawner.instance.OnEnemyKilled();
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
            //PlayerMovement playerMovement = col.gameObject.GetComponent<PlayerMovement>();
            //Vector3 forceDirection = (player.transform.position - transform.position).normalized;
            //playerMovement.Knockback()
        }
    }

}
