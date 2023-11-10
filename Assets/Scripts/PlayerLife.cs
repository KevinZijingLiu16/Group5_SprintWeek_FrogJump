using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AE0672
{

    public class PlayerLife : MonoBehaviour
    {

        public Image healthBar;
        public float health = 100f;
        public float damage = 25f;

        public float maxHealth = 100f;




        private Animator animator;

        private Rigidbody2D rb;

        [SerializeField] private AudioSource damageAudioSource;
        [SerializeField] private AudioSource rebornAudioSource;

        // Start is called before the first frame update
        private void Start()
        {
            health = maxHealth;

            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            UpdateHealthBar();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Trap"))
            {
                TakeDamage(damage);

            }
            if (collision.gameObject.CompareTag("Tongue"))
            {
                TakeDamage(damage);

            }



        }

        void UpdateHealthBar()
        {
            // Update the health bar based on the player's current health.
            float healthRatio = health / maxHealth;
            healthBar.fillAmount = healthRatio;
        }


        public void TakeDamage(float damageAmount)
        {
            health -= damageAmount;

            health = Mathf.Max(health, 0f);

            UpdateHealthBar();
            damageAudioSource.Play();

            if (health <= 0f)
            {
                Die();
                rebornAudioSource.Play();
            }
        }


        private void Die()
        {
            animator.SetTrigger("TriggerDeath");
            rb.bodyType = RigidbodyType2D.Static;

            Invoke("Reborn", 1.5f);
        }

        private void Reborn()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


    }

}
