using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AE0672
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;

        // Update is called once per frame
        private void Update()
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }

}