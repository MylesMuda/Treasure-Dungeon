using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject OpenedDoor;
    [SerializeField]
    GameObject closedDoor;
    // Update is called once per frame
    void Start()
    {
        CloseDoor();
        //OpenDoor();
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
