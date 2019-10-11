using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int enemyHealth;

    [SerializeField]
    public GameObject enemy;

    [SerializeField]
    private int maxHealth;

    void Start(){
        enemyHealth = maxHealth;
    } 

    public void DamageEnemy(){
        enemyHealth--;
        checkEnemyHealth();
    }

    public void checkEnemyHealth(){
        if(enemyHealth==0){
            Debug.Log("Enemy health is Zero");
            GameObject.Find("GameLogic").GetComponent<GameLogic>().SpawnEnemy(enemy);
        }
    }

    public void resetEnemyHealth(){
        enemyHealth = maxHealth;
    }
}
