using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PhysicsObject
{
    private Rigidbody2D rb2b;
    public PhysicsObject pO;
    public GameObject peter;
    public float maxSpeed = 7f;
    public float jumpTakeOffSpeed = 7f;
    Vector2 movement;
    
    private void Start()
    {
        rb2b = GetComponent<Rigidbody2D>();
        //instantiering af vores kode i
        peter = GetComponent<GameObject>();
        pO = GetComponent<PhysicsObject>();        
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

        
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.Space))        
        {            
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        
        
        //targetVelocity = move * maxSpeed;

        
        if (Input.GetKey(KeyCode.D))
        {
            targetVelocity.x = maxSpeed;                        
        }
        else if (Input.GetKey(KeyCode.A))
        {
            targetVelocity.x = maxSpeed * -1;                       
        }
        else
        {            
            targetVelocity.x = 0f;
        }             
    }
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
