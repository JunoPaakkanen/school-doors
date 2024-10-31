using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Next_Room_Loader : MonoBehaviour
{
    [SerializeField] private int roomCount = 5; // Editable in the Inspector
    private List<string> availableRooms = new List<string>();

    private void Start()
    {
        // Initialize the list with all room names
        for (int i = 1; i <= roomCount; i++)
        {
            string roomName = "Room_" + i.ToString("D2");
            availableRooms.Add(roomName);
            Debug.Log("Added to availableRooms: " + roomName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Log when the player collides with the trigger
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");

            if (availableRooms.Count > 0)
            {
                // Select a random room from the available rooms list
                int randomIndex = Random.Range(0, availableRooms.Count);
                string selectedRoom = availableRooms[randomIndex];
                Debug.Log("Attempting to load scene: " + selectedRoom);

                // Load the selected room and remove it from the list
                SceneManager.LoadScene(selectedRoom);
                availableRooms.RemoveAt(randomIndex);

                // Reset the list if all rooms have been loaded
                if (availableRooms.Count == 0)
                {
                    for (int i = 1; i <= roomCount; i++)
                    {
                        availableRooms.Add("Room_" + i.ToString("D2"));
                    }
                    Debug.Log("Room list reset.");
                }
            }
        }
    }
}
