using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnermyHealth : MonoBehaviour
{
    public Image enermyhealthBar;
    public float enermyHealth = 100f;
    public float bulletDamage = 10f;

    public float enermyMaxHealth = 100f;

    [SerializeField] private AudioSource enermyDamageAudioSource;
  

   




    

    private Rigidbody2D rb;

   

    // Start is called before the first frame update
    private void Start()
    {
        enermyHealth = enermyMaxHealth;

        rb = GetComponent<Rigidbody2D>();
        

        UpdateHealthBar();
     

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            TakeDamage(bulletDamage);
            Destroy(collision.gameObject);
            enermyDamageAudioSource.Play();


        }




    }

    void UpdateHealthBar()
    {
        // Update the health bar based on the player's current health.
        float healthRatio = enermyHealth / enermyMaxHealth;
        enermyhealthBar.fillAmount = healthRatio;
    }


    public void TakeDamage(float damageAmount)
    {
        enermyHealth -= damageAmount;

        enermyHealth = Mathf.Max(enermyHealth, 0f);

        UpdateHealthBar();
     

        if (enermyHealth <= 0f)
        {
            Die();
          
        }
    }


    private void Die()
    {
        // Find all game objects with the "tongue" tag
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Tongue");

        // Loop through the found objects and destroy each one
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }

        Destroy(gameObject);
        


    }

   

}
