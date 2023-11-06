using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    public float scaleSpeed = 1.0f;  // Adjust the speed of the scale change.
    public float scaleFactor = 2.0f; // The scale factor for the object.

    private Vector3 originalScale;
    private bool isScalingUp = true;

    void Start()
    {
        originalScale = transform.localScale; // Store the original scale of the object.
    }

    void Update()
    {
        // Calculate the new scale based on time and scale speed.
        float newScale = Mathf.PingPong(Time.time * scaleSpeed, scaleFactor);

        // Set the object's scale.
        transform.localScale = originalScale * newScale;

        // Check if the object should start scaling down.
        if (newScale >= scaleFactor - 0.01f)
        {
            isScalingUp = false;
        }
        // Check if the object should start scaling up.
        else if (newScale <= 0.01f)
        {
            isScalingUp = true;
        }
    }
}

