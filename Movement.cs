using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2b;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    
    private void Start()
    {
        rb2b = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        float speedH = Input.GetAxis("Horizontal");
        float speedV = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(speedH, speedV);
        rb2b.AddForce(movement);

        //rb2b.velocity = new Vector2(speedH, speedV);

    }


    /*
    void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown ("Jump"))
        {
            
        }
    }
    */
}
