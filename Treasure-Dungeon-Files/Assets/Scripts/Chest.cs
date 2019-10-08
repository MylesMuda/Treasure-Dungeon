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
        checkChests(); //CALL IN GAMELOGIC INSTEAD
        
        //gameObject.SetActive(false);
        // Destroy(gameObject);
        //chestAnimator.SetBool("Open", false);

    }

    IEnumerator removeChest(){
        yield return new WaitForSeconds(1f);
        var timeToFade = 0.7f;
        var currentTime = 0f;

        var spr = this.GetComponent<SpriteRenderer>();

        while(currentTime <= timeToFade){
             
            Mathf.Lerp(0,1,currentTime); // look up online lerp from alpha to 0
            currentTime -= Time.deltaTime;
        }
        Destroy(gameObject);
    }
}
