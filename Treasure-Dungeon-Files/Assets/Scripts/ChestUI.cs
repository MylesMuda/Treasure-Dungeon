using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestUI : MonoBehaviour
{
   public static int NoOfChests = 0;

   public Image[] chestImages;

   public Sprite chestOpened;

   public Sprite chestClosed;

   public void checkChests(){
        //Debug.Log($"Number of Chests is {NoOfChests}");

        if(NoOfChests == 3){
            GameObject.Find("Exit_Door").GetComponent<DoorController>().OpenDoor();
        }
    }

    public void displayChest(){
        for (int i = 0; i <= chestImages.Length; i++)
        {
            if (i == NoOfChests)
            {
                chestImages[i-1].sprite = chestOpened;
            }
        }
    }
}
