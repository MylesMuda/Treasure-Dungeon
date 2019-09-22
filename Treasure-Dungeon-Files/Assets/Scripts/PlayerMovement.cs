using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHair;
    public GameObject knifePrefab;

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

        //rb.velocity = movement;
        AimAndShoot();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        transform.position = transform.position + movement * moveSpeed * Time.deltaTime;
    }

    private void AimAndShoot()
    {
        Vector2 shootDirection = new Vector2(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"));

        if(aim.magnitude > 0.0f)
        {
            aim.Normalize();
            //aim *= 0.4f;
            crossHair.transform.localPosition = aim * aimDist;
            crossHair.SetActive(true);

            shootDirection.Normalize();
            if (Input.GetButtonDown("Attack"))
            {
                GameObject knife = Instantiate(knifePrefab, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 270f)));
                //knifePrefab.transform.Rotate(90, 0, 0);
                knife.GetComponent<Rigidbody2D>().velocity = shootDirection * 10f;
            }
        }
        else
        {
            crossHair.SetActive(false);
        }
    }

    private void ProcessInputs()
    {

    }
}
