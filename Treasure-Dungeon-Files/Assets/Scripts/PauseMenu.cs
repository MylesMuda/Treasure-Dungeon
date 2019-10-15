using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject PauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }        
    }

    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartMenu(){
        Debug.Log("Loading menu!");
        GameObject.Find("GameLogic").GetComponent<GameLogic>().RestartLevel();
    }

    public void QuitGame(){
        Debug.Log("Quitting Game!");
        Application.Quit();
    }
}
