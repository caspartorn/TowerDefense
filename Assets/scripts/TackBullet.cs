using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackBullet : MonoBehaviour
{
    public float speed = 20f; // Speed of the bullet
    public float lifetime = 2f; // Time before the bullet is destroyed
    public float maxDistance = 15f; // Maximum distance the bullet can travel

    private Vector3 direction;
    private Vector3 startPosition;

    void Start()
    {
        // Store the starting position of the bullet
        startPosition = transform.position;

        // Destroy the bullet after a certain lifetime
        Destroy(gameObject, lifetime);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized; // Normalize the direction vector
    }

    void Update()
    {
        // Move the bullet in the set direction
        transform.position += direction * speed * Time.deltaTime;

        // Check if the bullet has traveled beyond the maximum distance
        if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject); // Destroy the bullet if it exceeds max distance
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet hits an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Example: Destroy the enemy or deal damage
            Destroy(collision.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet on impact
            Debug.Log("Träff");
        }
    }
}