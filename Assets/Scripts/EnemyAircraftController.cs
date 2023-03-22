using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float altitudeChangeInterval = 5.0f;
    public Vector3[] altitudeLevels;

    private int currentAltitudeIndex = 0;
    private float timeSinceLastAltitudeChange = 0;

    private void Update()
    {
        // Move the aircraft left and right
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        // Change direction when reaching the screen edge
        if (transform.position.x < Camera.main.ViewportToWorldPoint(Vector3.zero).x ||
            transform.position.x > Camera.main.ViewportToWorldPoint(Vector3.one).x)
        {
            moveSpeed = -moveSpeed;
        }

        // Change altitude periodically
        timeSinceLastAltitudeChange += Time.deltaTime;
        if (timeSinceLastAltitudeChange >= altitudeChangeInterval)
        {
            timeSinceLastAltitudeChange = 0;
            ChangeAltitude();
        }
    }

    private void ChangeAltitude()
    {
        currentAltitudeIndex = (currentAltitudeIndex + 1) % altitudeLevels.Length;
        Vector3 newPosition = transform.position;
        newPosition.y = altitudeLevels[currentAltitudeIndex].y;
        transform.position = newPosition;
    }
}
