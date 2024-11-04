using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float rotationSpeed = 50f; // Increased rotation speed

    private bool isOpen = false; // Track the door's state
    private Quaternion closedRotation; // Initial rotation of the door
    private Quaternion openRotation; // Desired open rotation

    private void Start()
    {
        // Store the initial rotation
        closedRotation = transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, rotationAngle, 0);
    }

    private void Update()
    {
        // Rotate the door smoothly
        if (isOpen)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, openRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, closedRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger collider
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            isOpen = true; // Open the door
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger collider
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            isOpen = false; // Close the door
        }
    }
}
