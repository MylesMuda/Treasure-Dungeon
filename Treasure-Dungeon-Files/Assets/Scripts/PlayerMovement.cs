using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHair;

    [SerializeField]
    private int moveSpeed;

    [SerializeField]
    private int aimDist;

    [SerializeField]
    private Rigidbody2D rb;

    Vector3 movement;
    Vector3 aim;

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);
        aim = new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"), 0.0f);

        //if (Input.GetButton("Attack"))
        //{
        //    Debug.Log("Attack");
        //}

        //rb.velocity = movement;
        MoveCrosshair();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        transform.position = transform.position + movement * moveSpeed * Time.deltaTime;
    }

    private void MoveCrosshair()
    {
        if(aim.magnitude > 0.0f)
        {
            aim.Normalize();
            //aim *= 0.4f;
            crossHair.transform.localPosition = aim * aimDist;
            crossHair.SetActive(true);
        }
        else
        {
            crossHair.SetActive(false);
        }
    }

    private void AimAndHit()
    {

    }

    private void ProcessInputs()
    {

    }
}
