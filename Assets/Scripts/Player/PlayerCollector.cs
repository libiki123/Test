using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public float pullSpeed;
    private SphereCollider collectorCollider;
    private PlayerStats player;

    private Rigidbody pulledObjectRb;
    private bool pulling;

    private void Start()
    {
        player = GetComponentInParent<PlayerStats>();   
        collectorCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        collectorCollider.radius = player.currentMagnet;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect();
        }
    }
}
