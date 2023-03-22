using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftCollision : MonoBehaviour
{
    private AircraftManager aircraftManager;
    private int spawnIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            if (aircraftManager != null)
            {
                aircraftManager.AircraftDestroyed(spawnIndex);
            }
        }
    }

    public void SetSpawnIndex(int index)
    {
        spawnIndex = index;
    }

    public void SetAircraftManager(AircraftManager manager)
    {
        aircraftManager = manager;
    }
}
