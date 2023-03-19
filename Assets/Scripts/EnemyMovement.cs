using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyMovement : MonoBehaviour
{
    private EnemyStats enemy;
    private Transform target;
    private float rotateSpeed = 9f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy =  GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemy.currentMoveSpeed * Time.deltaTime);

        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, rotateSpeed * Time.deltaTime);
    }
}
