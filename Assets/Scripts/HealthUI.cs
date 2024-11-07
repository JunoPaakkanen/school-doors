using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public HealthSystem healthSystem;
    public UnityEngine.UI.Text healthPackStatus;

    void Update()
    {
        if (healthSystem.HasHealthPack())
        {
            healthPackStatus.text = "Health Pack: Available";
        }
        else
        {
            healthPackStatus.text = "Health Pack: Used";
        }
    }
}
