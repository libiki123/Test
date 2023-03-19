using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private bool useJoystick = true;
    private Vector3 moveDir;
    private float rotateSpeed = 13f;

    [Header("Knock Back")]
    [SerializeField] private float knockbackDuration;
    private bool knockBack;
    private float knockbackTimer;

    private PlayerStats player;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<PlayerStats>();
    }

    void Update()
    {
        InputManagement();
        CheckKnockBack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void InputManagement()
    {
        if (knockBack) return;

        float moveX;
        float moveZ;

        if (useJoystick)
        {
            moveX = joystick.Horizontal;
            moveZ = joystick.Vertical;
            moveDir = new Vector3(moveX, 0, moveZ) * player.currentMoveSpeed;
        }
        else
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveZ = Input.GetAxisRaw("Vertical");
            moveDir = new Vector3(moveX, 0, moveZ).normalized * player.currentMoveSpeed;
        }
    }

    private void Move()
    {
        Vector3 direction = Vector3.RotateTowards(transform.forward, moveDir, rotateSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);
        rb.MovePosition(rb.position + moveDir * Time.deltaTime);
    }

    //public void Knockback(Vector3 forceDir, float forceAmount)
    //{
    //    knockBack = true;
    //    knockbackTimer = knockbackDuration;

    //}

    private void CheckKnockBack()
    {
        //if (knockBack)
        //{
        //    knockbackTimer -= Time.deltaTime;
        //    if (knockbackTimer <= 0)
        //    {

        //    }
        //}
    }
}
