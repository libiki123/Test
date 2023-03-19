using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponController : WeaponController
{
    [SerializeField] private Transform endPoint;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        float angleStep = currentMaxAngle / currentnumberOfProjectile;
        Vector3 toPosition = (bulletSpawnLocation.position - endPoint.position).normalized;
        float angle = Utils.GetAngleFromVectorFloat(toPosition);
        angle -= (currentnumberOfProjectile - 1f) * angleStep / 2;

        for (int i = 0; i <= currentnumberOfProjectile - 1; i++)
        {
            float projectileDirXPos = bulletSpawnLocation.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float projectileDirYPos = bulletSpawnLocation.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 projectileVector = new Vector3(projectileDirXPos, projectileDirYPos, 0);
            Vector3 projectileMoveDirection = (projectileVector - bulletSpawnLocation.position).normalized;
            Vector3 dir = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y).normalized;
            //dir = Quaternion.AngleAxis(angle, Vector3.up) * dir;
            Vector3 rotation = new Vector3(0, Utils.GetAngleFromVectorFloat(dir), 0);

            GameObject tempObj = ObjectsPool.instance.GetProjectile(currentProjectileType);
            tempObj.transform.SetPositionAndRotation(bulletSpawnLocation.position, Quaternion.identity);
            tempObj.SetActive(true);
            tempObj.GetComponent<ProjectileBehaviour>().Setup(dir, rotation);

            angle += angleStep;
        }
    }
}
