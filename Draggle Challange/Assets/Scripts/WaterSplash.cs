using System;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    private bool particleAffected;

    private void OnParticleTrigger()
    {
        if (!particleAffected)
        {
            particleAffected = true;
            MakeTheEnemyAngry();
        }
    }

    private void MakeTheEnemyAngry()
    {
        FeverController.instance.IncreaseFever();
        
        // Activate the emojis
    }
}
