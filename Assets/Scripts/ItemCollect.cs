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

        public float bulletSpeed = 5f;

        [SerializeField] private TextMeshProUGUI melonCountText;
        [SerializeField] private TextMeshProUGUI bulletText;
        [SerializeField] private GameObject melonSeedBulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;

        [SerializeField] private AudioSource melonCollectAudioSource;

        private PlayerMovement playerMovement;
        [SerializeField] private AudioSource shootAudioSource;

       

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J)&& bulletCount >0 )
            {
                ShootMelonSeedBullet();
                shootAudioSource.Play();
                bulletCount--;
                bulletText.text = "Seed Bullets: " + bulletCount  ;
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

                // Provide 6 melon seed bullets for each melon collected
               
            }
        }

        private void ShootMelonSeedBullet()
        {
            GameObject bullet = Instantiate(melonSeedBulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            // Determine the direction based on the player's current movement direction
            float playerDirectionX = playerMovement.GetDirectionX();
            Debug.Log(playerDirectionX);

            // Set the bullet's initial velocity based on the direction
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(bulletSpeed * playerDirectionX, 0f);
        }



    }
}
