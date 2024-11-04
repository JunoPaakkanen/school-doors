using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerRoomGenerator : MonoBehaviour
{
    private RoomGenerator roomGenerator;
    private bool triggerUsed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject roomGeneratorObject = GameObject.Find("Room Generator");

        if (roomGeneratorObject != null)
        {
            roomGenerator = roomGeneratorObject.GetComponent<RoomGenerator>();
        }
        else
        {
            Debug.LogError("Room Generator GameObject was not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider doorTriggerCollider)
    {
        if (doorTriggerCollider.CompareTag("Player") && triggerUsed == false)
        {
                if (roomGenerator != null)
                {
                    // Call the GenerateRoom function in RoomGenerator script
                    Vector3 endOfRoom = transform.position;
                    Quaternion roomRot = transform.rotation;
                    roomGenerator.GenerateRoom(endOfRoom, roomRot);
                    triggerUsed = true;
                }
                else
                {
                    Debug.LogWarning("RoomGenerator component not assigned.");
                }  
        }
    }
}
