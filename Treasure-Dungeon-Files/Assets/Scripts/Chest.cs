using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator chestAnimator;

    private int NoOfChests = 3;

    void Update(){
        ChestOpen();
    }


    public void checkChests(){
        if(NoOfChests == 3){
            GameObject.Find("DoorController").GetComponent<DoorController>().OpenDoor();
        }
    }

    public void ChestOpen(){
        chestAnimator.SetBool("Open", true);
        NoOfChests++;
        // checkChests();
        // Destroy(gameObject);
    }
}
