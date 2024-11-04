using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;

    // Door rotation settings
    public float openAngle = 90f; // The angle to open the door
    public float doorSpeed = 2f;   // Speed of opening

    private void Update()
    {
        // Smoothly open the door if it is set to open
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, openAngle, 0), Time.deltaTime * doorSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            isOpen = true; // Open the door when the player enters the trigger
        }
    }
}
