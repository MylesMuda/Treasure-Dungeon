﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyHealth : MonoBehaviour
{
    private int enemyHealth;

    [SerializeField]
    private int maxHealth;

    public Rigidbody2D enemyRB;

    public Animator enemyAnim;

    void Start(){
        enemyHealth = maxHealth;
    } 

    public void DamageEnemy(){
        enemyHealth--;
        //enemyAnim.SetBool("isHurt", true);
        //gameObject.GetComponent<AIPath>().canMove = true;
        checkEnemyHealth();
    }

    public void checkEnemyHealth(){
        if(enemyHealth==0){
            Debug.Log("Enemy health is Zero");
            GameObject.Find("GameLogic").GetComponent<GameLogic>().SpawnEnemy(gameObject);
        }
    }

    public void resetEnemyHealth(){
        enemyHealth = maxHealth;
    }

    public IEnumerator EnemyKnockback(GameObject knife,  Vector2 knifePos){
        
        // var stunTime = 1.5f;
        // var stunStart = 0.0f;

        // while(stunStart < stunTime){
        //     stunStart += Time.deltaTime;
            gameObject.GetComponent<AIPath>().canMove = false;
            Vector3 knifeDir = knifePos;
            Vector3 moveDirection = gameObject.transform.position - knifeDir;
            enemyRB.AddForce(moveDirection * 30f);
            yield return new WaitForSeconds(0.5f);
            //yield return null;
            Debug.Log("Knockback");

            gameObject.GetComponent<AIPath>().canMove = true;
            
            //yield return null;
        //Debug.Log(moveDirection);
        //enemyRB.AddForce(transform.up * 500f + transform.right * 500f);
        //enemyAnim.SetBool("isHurt", false);
    }
    
}
