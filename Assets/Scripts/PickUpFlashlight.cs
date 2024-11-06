using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
    // The flashlight object to be enabled when picked up (assign this in the inspector)
    public GameObject flashlightToEnable;

    // The tag of the object that should trigger the pickup (e.g., "Player")
    public string targetTag = "Player";

    // Optional: You can add a sound effect when the player picks up the flashlight
    public AudioClip pickupSound;
    private AudioSource audioSource;

    // Optional: Particle system to play on pickup
    public ParticleSystem pickupEffect;

    void Start()
    {
        // Get AudioSource component (if any) attached to the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the flashlight is the player
        if (other.CompareTag(targetTag))
        {
            // Optionally, play a pickup sound
            if (pickupSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

            // Optionally, play a pickup particle effect
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }

            // Deactivate the current flashlight (this object)
            gameObject.SetActive(false);  // Or Destroy(gameObject) if you want to completely remove it

            // Enable the new flashlight (high-poly version)
            if (flashlightToEnable != null)
            {
                flashlightToEnable.SetActive(true);
            }
        }
    }
}
