using UnityEngine;

public class HealthPackLightController : MonoBehaviour
{
    // Reference to the indicator cylinder (health pack indicator)
    public GameObject healthPackIndicator; // The cylinder or indicator light

    void Start()
    {
        // Ensure the health pack indicator is initially disabled
        if (healthPackIndicator != null)
        {
            healthPackIndicator.SetActive(false);  // Disable the health pack indicator initially
        }
        else
        {
            Debug.LogError("HealthPackIndicator is not assigned in HealthPackLightController.");
        }
    }

    // Call this to enable the health pack indicator (cylinder)
    public void EnableIndicator()
    {
        Debug.Log("Enable Light called");
        if (healthPackIndicator != null)
        {
            healthPackIndicator.SetActive(true);  // Enable the health pack indicator
            Debug.Log("Health Pack Indicator Activated!");
        }
    }

    // Optional: Call this if you need to disable the indicator after health pack is used
    public void DisableIndicator()
    {
        if (healthPackIndicator != null)
        {
            healthPackIndicator.SetActive(false);  // Disable the health pack indicator
            Debug.Log("Health Pack Indicator Deactivated!");
        }
    }
}
