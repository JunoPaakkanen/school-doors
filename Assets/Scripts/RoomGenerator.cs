using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class RoomGenerator : MonoBehaviour
{

    public Vector3 RoomEnd;

    public List<GameObject> Rooms; //room prefabs

    public int RoomIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerateRoom(Vector3 EndOfRoom, Quaternion RoomRot)
    {

    RoomEnd = EndOfRoom;

    GameObject room = Rooms[Random.Range(0, Rooms.Count)];

    Instantiate(room,RoomEnd, RoomRot); 
        }
}
