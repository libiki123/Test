using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Pickup, ICollectible
{
    [SerializeField] private int healthGranted;

    public void Collect()
    {
        pulling = true;
        player.Heal(healthGranted);
    }
}
