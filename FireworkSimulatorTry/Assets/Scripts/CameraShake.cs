using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private void Awake()
    {
        instance = this;
    }
    // Duration of the shake effect
    public float shakeDuration = 0.5f;
    // Magnitude of the shake effect
    public float shakeMagnitude = 0.3f;

    // Reference to the camera's original position
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Store the original camera position
        originalPosition = transform.localPosition;
    }

    public void TriggerShake(float duration, float magnitude)
    {
        // Start the shake coroutine
        StartCoroutine(Shake(duration, magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // Random offset within the magnitude
            Vector3 randomPoint = originalPosition + (Vector3)Random.insideUnitCircle * magnitude;

            // Apply the random offset to the camera
            transform.localPosition = randomPoint;

            // Increment the time
            elapsed += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Restore the camera's original position
        transform.localPosition = originalPosition;
    }
}
