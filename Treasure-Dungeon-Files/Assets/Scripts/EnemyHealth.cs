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

    private Coroutine stunCoroutine = null;

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
            InitialiseEnemy();
            GameObject.Find("GameLogic").GetComponent<GameLogic>().SpawnEnemy(gameObject);
        }
    }

    public void resetEnemyHealth(){
        enemyHealth = maxHealth;
    }

    public IEnumerator EnemyKnockback(GameObject knife,  Vector2 knifePos){
        enemyAnim.SetBool("isHurt", true); 
        gameObject.GetComponent<AIPath>().canMove = false;
        Vector3 knifeDir = knifePos;
        Vector3 moveDirection = gameObject.transform.position - knifeDir;
        enemyRB.AddForce(moveDirection * 3f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<AIPath>().canMove = true;
        enemyAnim.SetBool("isHurt", false); 
    }

    IEnumerator StunTimer(){
        yield return new WaitForSeconds(1f);
    }

    public void CallKnockback(GameObject knife, Vector2 knifePos){
        this.stunCoroutine = StartCoroutine(EnemyKnockback(knife, knifePos));
    }

    public void InitialiseEnemy(){
        StopCoroutine(stunCoroutine);
        gameObject.GetComponent<AIPath>().canMove = true;
        enemyAnim.SetBool("isHurt", false); 
        if (enemyRB){
            enemyRB.velocity = Vector3.zero;
        }
    }    
}
