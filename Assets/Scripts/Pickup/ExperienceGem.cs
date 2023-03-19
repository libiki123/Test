using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : Pickup, ICollectible
{
    [SerializeField] private int experienceGranted;

    public void Collect()
    {
        pulling = true;
        player.IncreaseExperience(experienceGranted);
    }

}
