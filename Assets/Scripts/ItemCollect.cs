using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AE0672
{
    public class ItemCollect : MonoBehaviour
    {
        private int melonCount = 0;
        [SerializeField] private TextMeshProUGUI melonCountText;
        [SerializeField] private AudioSource melonCollectAudioSource;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Melon"))
            {
                melonCollectAudioSource.Play();

                Destroy(collision.gameObject);

                melonCount++;

                melonCountText.text = "Melons Collection: " + melonCount;
            }
        }
    }

}