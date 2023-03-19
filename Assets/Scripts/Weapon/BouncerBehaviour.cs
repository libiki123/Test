using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerBehaviour : ProjectileBehaviour
{
    private Transform player;
    private Vector3 randLocation;
    private bool locationReached;
    private float t;

    protected override void OnEnable()
    {
        base.OnEnable();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GetRandomLocation();
    }

    private void Update()
    {
        if(!locationReached)
        {
            transform.position = Vector3.Lerp(transform.position, randLocation, currentSpeed/10 * Time.deltaTime);

            if(Vector3.Distance(transform.position, randLocation) <= 0.01f)
            {
                locationReached = true;
                GetRandomLocation();
            }
        }
    }

    private void GetRandomLocation()
    {
        locationReached = false;
        randLocation = new Vector3(player.position.x + Random.Range(-20f, 20f), transform.position.y, player.position.z + Random.Range(-20f, 20f));
    }
}
