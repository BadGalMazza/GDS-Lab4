using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    private bool isAlive = true;

    public bool IsAlive()
    {
        return isAlive;
    }

    public void DestroyCity()
    {
        isAlive = false;
        // Add any additional logic for city destruction visuals here
    }
}
