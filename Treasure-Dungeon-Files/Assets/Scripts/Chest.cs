using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Animator chestAnimator;

    //public static int NoOfChests = 0;

    public bool isOpen = false;

    //public Image[] chestImages;

    // public void checkChests(){
    //     //Debug.Log($"Number of Chests is {NoOfChests}");

    //     if(NoOfChests == 3){
    //         GameObject.Find("Exit_Door").GetComponent<DoorController>().OpenDoor();
    //     }
    // }
    
    public void ChestOpen(){
        if(!isOpen){
            chestAnimator.SetBool("Open", true);
            ChestUI.NoOfChests++;
            //gameObject.SetActive(false);
            GameObject.Find("Chests").GetComponent<ChestUI>().displayChest();
            StartCoroutine(removeChest());
            isOpen = true;
        }
    }

    IEnumerator removeChest(){
        yield return new WaitForSeconds(1.2f);
        var timeToFade = 1.5f;
        var currentTime = 0.0f;

        var spr = this.GetComponent<SpriteRenderer>();

        while(currentTime < timeToFade){
            //Debug.Log(currentTime);
            currentTime += Time.deltaTime;
            
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b,  Mathf.Lerp(1f, 0f, currentTime/timeToFade));

            yield return null;
        }
        
        GameObject.Find("Chests").GetComponent<ChestUI>().checkChests();
        //gameObject.SetActive(false);
        Destroy(this.gameObject);

    }
}