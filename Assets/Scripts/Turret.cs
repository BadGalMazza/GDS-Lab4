using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject crosshair;
    public float crosshairSpeed = 5.0f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;
    public Transform spawnPoint; // Add this variable

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 crosshairMovement = new Vector3(horizontalInput, verticalInput, 0) * crosshairSpeed * Time.deltaTime;
        crosshair.transform.position += crosshairMovement;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        Vector3 direction = (crosshair.transform.position - transform.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        if (projectileRigidbody != null)
        {
            projectileRigidbody.velocity = direction * projectileSpeed;
            //Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Projectile does not have a Rigidbody2D component.");
        }
    }

}
