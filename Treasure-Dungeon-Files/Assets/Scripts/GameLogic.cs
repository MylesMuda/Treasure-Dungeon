﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject coin;

    public GameObject[] spawnPoints;

    public void SpawnEnemy(GameObject enemy){
        Instantiate(coin, enemy.transform.position, Quaternion.identity);

        GameObject spawnPoint = GetRandomSpawnPoint();
        enemy.transform.position = spawnPoint.transform.position;
        enemy.GetComponent<EnemyHealth>().resetEnemyHealth();
        Score.score += 100;
    }

    GameObject GetRandomSpawnPoint(){
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Test-Area");
        Score.score = 0;
        ChestUI.NoOfChests=0;
    }
}
