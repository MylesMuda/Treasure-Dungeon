using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public GameObject[] spawnPoints;

    //public static int NoOfChests = 0;

    public void SpawnOgre(GameObject Ogre){
        GameObject spawnPoint = GetRandomSpawnPoint();
        Ogre.transform.position = spawnPoint.transform.position;
        //GameObject.Find("Score").GetComponent<Score>().score;
        Score.score += 100;
    }

    GameObject GetRandomSpawnPoint(){
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    // public void checkChests(){
    //     Debug.Log($"Number of Chests is {NoOfChests}");
    //     if(NoOfChests == 3){
    //         GameObject.Find("Exit_Door").GetComponent<DoorController>().OpenDoor();
    //     }
    //     else if(NoOfChests > 3){
    //         NoOfChests = 3;
    //     }
    // }

}
