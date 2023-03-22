using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource source;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("FriendlyRocket"))
        {
            source.PlayOneShot(audioClip);
            BounceOffRocket();
        }
    }

    private void BounceOffRocket()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Calculate the reflected velocity along the vertical direction
        Vector2 verticalNormal = new Vector2(1, 0);
        Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, verticalNormal);

        // Extend the horizontal movement of the projectile
        reflectedVelocity.x *= 2;

        rb.velocity = reflectedVelocity;
    }

    
}

