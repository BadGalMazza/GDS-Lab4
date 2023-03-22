using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform spawnPoint;
    public float firingCooldown = 3.0f;

    private float timeSinceLastFiring = 0;
    public float rocketSpeed = 5.0f;

    private void Update()
    {
        timeSinceLastFiring += Time.deltaTime;
        if (timeSinceLastFiring >= firingCooldown)
        {
            FireRocket();
            timeSinceLastFiring = 0;
        }
    }

    //private void FireRocket()
    //{
        //Instantiate(rocketPrefab, spawnPoint.position, spawnPoint.rotation);
   // }
    private void FireRocket()
    {
        GameObject rocket = Instantiate(rocketPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
        rb.velocity = spawnPoint.up * rocketSpeed;
    }
}

