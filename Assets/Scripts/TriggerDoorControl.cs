using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorControl : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myDoor.Play("open", 0, 0.0f);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            myDoor.Play("close", 0, 0.0f);
        }
    }
}