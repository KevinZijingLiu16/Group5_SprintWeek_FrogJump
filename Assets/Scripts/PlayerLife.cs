using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AE0672
{
    public class PlayerLife : MonoBehaviour
    {
        private Animator animator;

        private Rigidbody2D rb;

        [SerializeField] private AudioSource deathAudioSource;
        [SerializeField] private AudioSource rebornAudioSource;

        // Start is called before the first frame update
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Trap"))
            {
                Die();
               
            }
        }

        private void Die()
        {
            animator.SetTrigger("TriggerDeath");
            rb.bodyType = RigidbodyType2D.Static;
            deathAudioSource.Play();
        }

        private void Reborn()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            rebornAudioSource.Play();
        }


    }

}