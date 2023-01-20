using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSideChecker : MonoBehaviour
{
    private Door door;
    private PlayerMovementMobile playerMovementMobile;
    [SerializeField] private GameObject Door;

    void Start()
    {
        door = Door.GetComponent<Door>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementMobile>())
        {
            door.DoorForwardBoolSwitch();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovementMobile>())
        {
            door.DoorForwardBoolSwitch();
        }
    }
}

