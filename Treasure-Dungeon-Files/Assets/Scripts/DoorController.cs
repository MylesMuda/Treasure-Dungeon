using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    GameObject OpenedDoor;
    [SerializeField]
    GameObject closedDoor;
    void Start()
    {
        CloseDoor();
    }

    public void OpenDoor(){
        OpenedDoor.SetActive(true);
        closedDoor.SetActive(false);
    }

    public void CloseDoor(){
        closedDoor.SetActive(true);
        OpenedDoor.SetActive(false);
    }
}