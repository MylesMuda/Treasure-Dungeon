using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHair;
    public GameObject knifePrefab;
    public GameObject throwPoint;    
    public bool useController = false;
    public PlayerHealth playerHealth;

    [SerializeField]
    private int moveSpeed;

    [SerializeField]
    private int aimDist;

    [SerializeField]
    private Rigidbody2D rb;


    Vector3 movement;
    Vector3 aim;
    bool isAiming;
    bool stopAiming;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        AimAndShoot();
        Animate();
        Move();
        //onCollisionWithEnemy();
    }

    private void Move()
    {
        //transform.position = transform.position + movement * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector2(movement.x, movement.y) * moveSpeed;
    }

    private void AimAndShoot()
    {
        Vector2 shootDirection = new Vector2(aim.x, aim.y);

        if (aim.magnitude > 0.0f)
        {
            crossHair.transform.localPosition = aim * aimDist;
            crossHair.SetActive(true);

            shootDirection.Normalize();
            if (stopAiming)
            {
                GameObject knife = Instantiate(knifePrefab, throwPoint.transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 270f)));
                //knifePrefab.transform.Rotate(90, 0, 0);
                knife knifeScript = knife.GetComponent<knife>();
                knifeScript.velocity = shootDirection * 15f;
                knifeScript.knight = gameObject;
                knife.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);
                //Destroy(knife, 1.0f);
            }
        }
        else
        {
            crossHair.SetActive(false);
        }

    }

    private void ProcessInputs()
    {
        string[] NoOfControllers = Input.GetJoystickNames();

        //switch to controller if controller is detected
        if(NoOfControllers.Length > 0)
        {
            foreach(var controller in NoOfControllers)
            {
                if (!string.IsNullOrEmpty(controller))
                {
                    useController = true;
                }
                else
                {
                    useController = false;
                }
            }
        }

        if (useController)
        {
            movement = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0.0f);
            aim = new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"), 0.0f);
            aim.Normalize();
            isAiming = Input.GetButton("Attack");
            stopAiming = Input.GetButtonUp("Attack");
        }
        else
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
            aim += mouseMovement;
            if (aim.magnitude > 1.0f)
            {
                aim.Normalize();
            }
            //aim.Normalize();
            isAiming = Input.GetButton("Fire1");
            stopAiming = Input.GetButtonUp("Fire1");
        }

        if (movement.magnitude > (1.0f))
        {
            movement.Normalize();
            
        }

    }

    private void Animate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Damage();
        }
    }

    void Damage()
    {
        playerHealth.health--;
        if(playerHealth.health <= 0)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Test-Area");
    }
}
