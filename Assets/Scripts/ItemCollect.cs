using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AE0672
{
    public class ItemCollect : MonoBehaviour
    {
        private int melonCount = 0;
        private int bulletCount = 0;

        public float bulletSpeed = 20f;

        [SerializeField] private TextMeshProUGUI melonCountText;
        [SerializeField] private TextMeshProUGUI bulletText;
        [SerializeField] private GameObject melonSeedBulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;

        [SerializeField] private AudioSource melonCollectAudioSource;
        [SerializeField] private AudioSource shootAudioSource;

        private PlayerMovement playerMovement;
        SpriteRenderer SpriteRenderer;

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J) && bulletCount > 0)
            {
                ShootMelonSeedBullet();
                shootAudioSource.Play();
                bulletCount--;
                bulletText.text = "Seed Bullets: " + bulletCount;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Melon"))
            {
                melonCollectAudioSource.Play();

                Destroy(collision.gameObject);

                melonCount++;

                melonCountText.text = "Melons Collected: " + melonCount;

                bulletCount += 3;

                bulletText.text = "Melon Seed Bullets: " + bulletCount;
            }
        }

        private void ShootMelonSeedBullet()
        {
            // Get the player's position
            Vector2 playerPosition = transform.position;

            // Calculate the offset based on the player's facing direction
            float xOffset = playerMovement.IsFacingRight() ? 1f : -1f;

            // Calculate the spawn position for the bullet
            Vector2 bulletSpawnPosition = new Vector2(playerPosition.x + xOffset, playerPosition.y);

            // Instantiate the bullet at the calculated spawn position
            GameObject bullet = Instantiate(melonSeedBulletPrefab, bulletSpawnPosition, Quaternion.identity);

            // Set the bullet's velocity based on the player's facing direction
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * xOffset, 0f);
        }

    }
}

