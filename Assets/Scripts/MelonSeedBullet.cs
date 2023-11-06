using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonSeedBullet : MonoBehaviour
{
    public float bulletSpeed = 100f;


    private void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Handle enemy hit logic (e.g., destroy the enemy)
            Destroy(collision.gameObject);
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
