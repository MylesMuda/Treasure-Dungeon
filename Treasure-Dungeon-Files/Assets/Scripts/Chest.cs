using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator chestAnimator;

    public static int NoOfChests = 0;

    public void checkChests(){
        Debug.Log($"Number of Chests is {NoOfChests}");
        if(NoOfChests == 3){
            GameObject.Find("Exit_Door").GetComponent<DoorController>().OpenDoor();
        }
    }
    
    public void ChestOpen(){
        chestAnimator.SetBool("Open", true);
        NoOfChests++;
        checkChests();
        
        //gameObject.SetActive(false);
        // Destroy(gameObject);
        //chestAnimator.SetBool("Open", false);
    }
}
