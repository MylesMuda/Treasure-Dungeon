using System.Collections;
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

    public void EnemyKnockback(GameObject knife,  Vector2 knifePos){
        
        // var stunTime = 1.5f;
        // var stunStart = 0.0f;

        // while(stunStart < stunTime){
        //     stunStart += Time.deltaTime;
        gameObject.GetComponent<AIPath>().canSearch = false;
        Vector3 knifeDir = knifePos;
        Vector3 moveDirection = knifeDir - gameObject.transform.position;
        enemyRB.AddForce(moveDirection * 300f);
            //StartCoroutine(StunTimer());
            //yield return null;
        Debug.Log("Knockback");
            //gameObject.GetComponent<AIPath>().canSearch = true;
            
            //yield return null;
        //Debug.Log(moveDirection);
        //enemyRB.AddForce(transform.up * 500f + transform.right * 500f);
        //enemyAnim.SetBool("isHurt", false);
    }

    IEnumerator StunTimer(){
        yield return new WaitForSeconds(1f);
    }
    
}
