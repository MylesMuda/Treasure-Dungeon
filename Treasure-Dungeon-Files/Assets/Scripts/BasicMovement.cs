using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private int moveSpeed;

    [SerializeField]
    private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        

        Vector3 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //if (Input.GetButton("Attack"))
        //{
        //    Debug.Log("Attack");
        //}

        //rb.velocity = movement;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        transform.position = transform.position + movement * moveSpeed * Time.deltaTime;
    }
}
