using UnityEngine;

public class Door_Mehcanism : MonoBehaviour
{
    public GameObject door; // Reference to the door object

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Option 1: Disable door collider to allow passage
            door.GetComponent<Collider>().enabled = false;

            // Option 2: Trigger door open animation (if animated)
            // door.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Re-enable the door collider once the player leaves
            door.GetComponent<Collider>().enabled = true;
        }
    }
}

