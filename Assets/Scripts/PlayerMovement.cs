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
    [SerializeField] private Vector2 knockbackSpeed;
    private bool knockBack;
    private float knockbackStartTime;

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

    public void Knockback(Vector3 forceDir, float forceAmount)
    {
        //knockBack = true;
        //knockbackStartTime = Time.time;
        //rb.velocity = new Vector2(knockbackSpeed.x * forceDir, knockbackSpeed.y);
    }

    private void CheckKnockBack()
    {
        if (Time.time > knockbackStartTime + knockbackDuration && knockBack)
        {
            knockBack = false;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);     // stop the knockback
        }
    }
}
