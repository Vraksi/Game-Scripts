using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PhysicsObject
{    
    private Rigidbody2D rb2b;
    public float maxSpeed = 7f;
    public float jumpTakeOffSpeed = 7f;
    private bool jumpTrue = false;
    private Detect detect;
    Vector2 movement;
    public Animator animator;  

    private void Start()
    {
        detect = GameObject.FindObjectOfType<Detect>();
        rb2b = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            print("Du dashede");
            velocity.y = 0;
            velocity.x = 40;
        }
    }

    public void jump()
    {
        jumpTrue = detect.jumpTest();

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
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-3.4f, 3.8f, 2f);
            targetVelocity.x = maxSpeed * -1;
        }
        else
        {
            targetVelocity.x = 0f;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag != "Player")
    //    {
    //        HasLanded();
    //    }

    //}

    //private void HasLanded()
    //{
    //    animator.SetBool("isFalling", false);
    //    animator.SetBool("HasLanded", true);
    //    if (animator.GetBool("HasLanded"))
    //    {
    //        velocity.y = 0;
    //    }
    //}


    /*
    private void FixedUpdate()
    {
        
        float speedH = Input.GetAxis("Horizontal");
        float speedV = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(speedH, speedV);
        rb2b.AddForce(movement);

        //rb2b.velocity = new Vector2(speedH, speedV);

    }
    */
}
