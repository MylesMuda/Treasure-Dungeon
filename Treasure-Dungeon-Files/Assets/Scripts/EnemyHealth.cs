using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void EnemyKnockback(Vector2 knife){     
        Vector3 knifeDir = knife;
        Vector3 moveDirection = gameObject.transform.position - knifeDir;
        enemyRB.AddForce(moveDirection.normalized * 4000f);
        //enemyAnim.SetBool("isHurt", false);
    }
    
}
