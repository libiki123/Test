using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private PlayerCollector collector;
    protected PlayerStats player;
    //private Rigidbody rb;
    protected bool pulling;

    virtual protected void Start()
    {
        GameObject playerGo = GameObject.FindGameObjectWithTag("Player");
        player = playerGo.GetComponent<PlayerStats>();
        collector = playerGo.GetComponentInChildren<PlayerCollector>();
        //rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (pulling)
        {
            //Vector3 dir = (player.transform.position - transform.position).normalized;
            //transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, collector.pullSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, player.transform.position, collector.pullSpeed/10 * Time.deltaTime);
        }

        //if (pulling)
        //{
        //    float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        //    if (distanceToPlayer > 0)
        //    {
        //        Vector3 forceDirection = (player.transform.position - transform.position).normalized;
        //        rb.AddForce(forceDirection * collector.pullSpeed, ForceMode.Force);
        //    }
        //}
    }

    virtual protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pulling = false;
            gameObject.SetActive(false);
        }
    }
}
