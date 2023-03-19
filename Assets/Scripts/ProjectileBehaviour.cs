using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] protected Weapon_SO weaponData;
    [SerializeField] protected float destroyAfterSeconds;

    protected Vector3 direction;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.ProjectileSpeed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    virtual protected void OnEnable()
    {
        currentPierce = weaponData.Pierce;
        Invoke(nameof(Destroy), destroyAfterSeconds);
    }

    public void Setup( Vector3 rotation)
    {
        transform.eulerAngles = rotation;
    }

    public void Setup(Vector3 dir, Vector3 rotation)
    {
        direction = dir;
        transform.eulerAngles = rotation; 
    }

    protected void Destroy()
    {
        gameObject.SetActive(false);
    }
    
    private void ReducePeierce()
    {
        currentPierce--;
        if(currentPierce <= 0)
        {
            Destroy();
        }
    }

    virtual protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            ReducePeierce();
        }
        else if (other.CompareTag("Prob"))
        {
            if (other.gameObject.TryGetComponent(out BreakableProb breakable))
            {
                breakable.TakeDamage(currentDamage);
                ReducePeierce();
            }
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }


}
