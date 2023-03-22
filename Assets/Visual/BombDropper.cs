using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public GameObject bombPrefab;
    public float bombDropInterval = 3.0f;
    public City[] cities; // Change the type from GameObject[] to City[]
    public float cityWidth = 1.0f;

    private float timeSinceLastBombDrop = 0;
    private bool canDropBombs = false;

    private void Update()
    {
        if (canDropBombs)
        {
            timeSinceLastBombDrop += Time.deltaTime;
            if (timeSinceLastBombDrop >= bombDropInterval && IsAboveAliveCity()) // Change the method name
            {
                timeSinceLastBombDrop = 0;
                DropBomb();
            }
        }
    }

    private void DropBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }

    public void StartDroppingBombs()
    {
        canDropBombs = true;
    }

    public void StopDroppingBombs()
    {
        canDropBombs = false;
    }

    private bool IsAboveAliveCity() // Change the method name
    {
        float aircraftX = transform.position.x;
        foreach (City city in cities)
        {
            if (city.IsAlive()) // Check if the city is alive
            {
                float cityX = city.transform.position.x;
                if (Mathf.Abs(aircraftX - cityX) <= cityWidth / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
