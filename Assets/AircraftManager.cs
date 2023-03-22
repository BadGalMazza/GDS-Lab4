using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AircraftManager : MonoBehaviour
{
    public GameObject enemyAircraftPrefab;
    public float spawnDelay = 2.0f;
    public int maxAircraftDestroyed = 8;
    public Vector3[] spawnPositions;
    public float bombDropInterval = 3.0f; // Add this line

    private int aircraftDestroyed = 0;
    private GameObject[] activeAircraft;
    private int currentBombDropperIndex = 0; // Add this line

    private void Start()
    {
        activeAircraft = new GameObject[spawnPositions.Length];

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            SpawnAircraft(i);
        }

        StartCoroutine(SwitchBombDropper()); // Add this line
    }

    public void AircraftDestroyed(int spawnIndex)
    {
        if (aircraftDestroyed < maxAircraftDestroyed)
        {
            aircraftDestroyed++;
            StartCoroutine(SpawnAircraftWithDelay(spawnIndex, spawnDelay));
        }
    }

    private void SpawnAircraft(int spawnIndex)
    {
        if (activeAircraft[spawnIndex] == null)
        {
            activeAircraft[spawnIndex] = Instantiate(enemyAircraftPrefab, spawnPositions[spawnIndex], Quaternion.identity);
            activeAircraft[spawnIndex].GetComponent<AircraftCollision>().SetSpawnIndex(spawnIndex);
            activeAircraft[spawnIndex].GetComponent<AircraftCollision>().SetAircraftManager(this);
        }
    }

    private IEnumerator SpawnAircraftWithDelay(int spawnIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnAircraft(spawnIndex);
    }

    private IEnumerator SwitchBombDropper() // Modify this method
    {
        while (true)
        {
            yield return new WaitForSeconds(bombDropInterval);

            if (activeAircraft[currentBombDropperIndex] != null)
            {
                activeAircraft[currentBombDropperIndex].GetComponent<BombDropper>().StopDroppingBombs();
            }

            currentBombDropperIndex = (currentBombDropperIndex + 1) % activeAircraft.Length;

            if (activeAircraft[currentBombDropperIndex] != null)
            {
                activeAircraft[currentBombDropperIndex].GetComponent<BombDropper>().StartDroppingBombs();
            }
        }
    }

}
