
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackShooter : MonoBehaviour
{
    [Header("Stats")]
    public float range = 15f;
    public string enemyTag = "Enemy";
    public float fireRate = 1f; // 1 shot per second
    private float fireCountdown = 0f;

    [Header("Unity")]
    public Transform[] firePoints; // Array to hold multiple fire points
    public GameObject tackBulletPrefab; // Reference to the TackBullet prefab

    private List<Transform> enemiesInRange = new List<Transform>();

    void Update()
    {
        // Check if there are any enemies in range
        if (enemiesInRange.Count > 0)
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints) // Iterate through each fire point
        {
            GameObject bulletGO = Instantiate(tackBulletPrefab, firePoint.position, firePoint.rotation);
            TackBullet bullet = bulletGO.GetComponent<TackBullet>();

            if (bullet != null)
            {
                // Set the bullet's direction to the forward direction of the fire point
                bullet.SetDirection(firePoint.forward);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            // Add the enemy to the list if it's within range
            enemiesInRange.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            // Remove the enemy from the list when it exits the range
            enemiesInRange.Remove(other.transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnEnable()
    {
        // Create a trigger collider for the turret
        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = range;
    }

}
