using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public GameObject knight;

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPos = currentPos + velocity * Time.deltaTime;

        RaycastHit2D[] hits = Physics2D.LinecastAll(currentPos, newPos);

        //Debug.DrawLine(currentPos, newPos, Color.red);

        foreach(RaycastHit2D hit in hits)
        {
            GameObject other = hit.collider.gameObject;
            if(other != knight)
            {
                if (other.CompareTag("Enemy"))
                {
                    Destroy(gameObject);
                    GameObject.Find("GameLogic").GetComponent<GameLogic>().SpawnOgre(other);
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
}
