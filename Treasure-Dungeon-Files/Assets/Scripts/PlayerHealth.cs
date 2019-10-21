using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
  
    public int health;

    [SerializeField]
    private int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public Rigidbody2D playerRB;
    private Coroutine knockbackCoroutine;

    public void Update()
    {
        PlayerHealthCheck();
    }

    public void PlayerHealthCheck()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Damage()
    {
        health--;
        if(health <= 0)
        {
            GameObject.Find("GameLogic").GetComponent<GameLogic>().RestartLevel();
        }
    }

    public void CallKnockback(Vector3 knockbackDirection){
        this.knockbackCoroutine = StartCoroutine(PlayerKnockback(knockbackDirection));
    }

    public IEnumerator PlayerKnockback(Vector3 knockbackDirection){
        Debug.Log("Entered Coroutine");
        gameObject.GetComponent<PlayerMovement>().animator.SetBool("IsHurt", true);
        Vector3 moveDirection = gameObject.transform.position - knockbackDirection;
        playerRB.AddForce(moveDirection * -30f, ForceMode2D.Impulse);
        Debug.Log("Added force");
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<PlayerMovement>().animator.SetBool("IsHurt", false);
    }

}
