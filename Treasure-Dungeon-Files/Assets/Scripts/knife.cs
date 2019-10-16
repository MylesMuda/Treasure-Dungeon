using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class knife : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public GameObject knight;

    void Update()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPos = currentPos + velocity * Time.deltaTime;

        RaycastHit2D[] hits = Physics2D.LinecastAll(currentPos, newPos);

        foreach(RaycastHit2D hit in hits)
        {
            GameObject other = hit.collider.gameObject;
            if(other != knight)
            {
                if (other.CompareTag("Enemy"))
                {
                    
                    other.GetComponent<EnemyHealth>().EnemyKnockback(this.gameObject, newPos);
                    //other.GetComponent<EnemyHealth>().EnemyKnockback(newPos);
                    other.GetComponent<EnemyHealth>().DamageEnemy();
                    // CALL COROUTINE TIMER
                    StartCoroutine(StunTimer());
                    other.GetComponent<AIPath>().canSearch = true;
                    //this.gameObject.SetActive(false);
                    Destroy(gameObject);
                    break;

                }

                if (other.CompareTag("Object"))
                {
                    Destroy(gameObject);
                    break;
                }

                if (other.CompareTag("Wall"))
                {
                    Destroy(gameObject);
                    break;
                }
            }
        }
        transform.position = newPos;
    }

    IEnumerator StunTimer(){
        yield return new WaitForSeconds(1f);
    }
}
