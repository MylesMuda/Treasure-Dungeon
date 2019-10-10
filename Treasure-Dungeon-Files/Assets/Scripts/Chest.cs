using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Animator chestAnimator;

    public bool isOpen = false;
    
    public void ChestOpen(){
        if(!isOpen){
            chestAnimator.SetBool("Open", true);
            ChestUI.NoOfChests++;
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
            currentTime += Time.deltaTime;
            
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b,  Mathf.Lerp(1f, 0f, currentTime/timeToFade));

            yield return null;
        }
        
        GameObject.Find("Chests").GetComponent<ChestUI>().checkChests();
        Destroy(this.gameObject);

    }
}