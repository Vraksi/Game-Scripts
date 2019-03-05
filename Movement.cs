using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PhysicsObject
{    
    private Rigidbody2D rb2;
    private Detect detect;
    Vector2 movement;

    private bool jumpTrue = false;
    private bool direction = true;
    public Animator animator;
    public float maxSpeed = 7f;
    public float jumpTakeOffSpeed = 7f;

    private float dashTimeCd;
    public float dashTime = 2f;
    private float cd;
    public float dashCd = 2f;
    private bool dashTrue = true;

    public float dashSpeed = 40;
    //public float startDashTime; 
    //private float dashTime;
    //public float time = 2;

    private bool dashing;



    private void Start()
    {
        detect = GameObject.FindObjectOfType<Detect>();
        rb2 = GetComponent<Rigidbody2D>();
        dashTimeCd = dashTime;
        cd = dashCd;
        //instantiering af vores kode i       
        //detect123 = GetComponent<Detect>;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // måder at kalde metoder på i unity
        // Vi kan kun kalde en metode i vores neda rvede klasse hvis vi gør dem public
        Gravity();

        //peter.SendMessage("Gravity");
        // alt koden i pO er fra PhysicsObject og metoder kan kaldes ved at skrive pO
        //pO.Gravity();

        //Vector2 move = Vector2.zero;

        //move.x = Input.GetAxis("Horizontal");

        //jumpTrue                


        //targetVelocity = move * maxSpeed;
        
        animator.SetFloat("Speed", Mathf.Abs(targetVelocity.x));
        animator.SetFloat("VerticalSpeed", velocity.y);
        detect.Falling(velocity);
        jump();
        walk();
        Dash();
    }

    public void Dash()
    {
        cd = cd - Time.smoothDeltaTime;
        dashTrue = detect.dashTrue;        
        if (Input.GetKeyDown(KeyCode.R) && dashTrue)
        {
            if (cd <= 0)
            {
                dashing = true;
            }
        }

        //TODO kode der stopper vores dash hvis vi rammer en væg
        if (dashing)
        {
            animator.SetBool("isDashing", true);
            dashTimeCd = dashTimeCd - Time.smoothDeltaTime;           
            if (direction && dashTimeCd >= 0)
            {
                //print("Du dashede til højre");
                gravityModifier = 0;
                velocity.y = 0;
                velocity.x = targetVelocity.x = dashSpeed;                              
            }
            else if (!direction && dashTimeCd >= 0)
            {
                //print("Du dashede til venstre");
                gravityModifier = 0;
                velocity.y = 0;
                velocity.x = targetVelocity.x = dashSpeed * -1f;                            
            }            
        }
        if (dashTimeCd <= 0)
        {
            targetVelocity.x = 0;
            dashing = false;
            dashTimeCd = dashTime;
            cd = dashCd;
            gravityModifier = 1;
            detect.dashTrue = false;
            animator.SetBool("isDashing", false);
        }
    }

    public void jump()
    {
        jumpTrue = detect.JumpTest();

        if (Input.GetKeyDown(KeyCode.Space) && jumpTrue)
            {
                animator.SetBool("isJumping", true);
                velocity.y = jumpTakeOffSpeed;                               
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                
                if (velocity.y > 0)
                {                    
                    velocity.y = velocity.y * 0.5f;                    
                }
            }
    }

    private void walk()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(3.4f, 3.8f, 2f);
            targetVelocity.x = maxSpeed;
            direction = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-3.4f, 3.8f, 2f);
            targetVelocity.x = maxSpeed * -1;
            direction = false;
        }
        else if (!dashing && Input.GetKeyUp(KeyCode.A))
        {
            targetVelocity.x = 0f;
        }
        else if (!dashing && Input.GetKeyUp(KeyCode.D))
        {
            targetVelocity.x = 0f;
        }
    }
}
