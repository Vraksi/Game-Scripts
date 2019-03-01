using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public bool jumpTrue;
    private Rigidbody2D rb2b;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            jumpTrue = true;
            animator.SetBool("HasLanded", true);
            animator.SetBool("isFalling", false);
        }
        //if (collision.gameObject.tag == "Platform")
        //{
        //    animator.SetBool("isFalling", false);

        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            jumpTrue = false;
            animator.SetBool("isFalling", true);
            animator.SetBool("HasLanded", false);
        }
    }



    public void Falling(Vector2 velocity)
    { 
        if (velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }
        else if (velocity.y > 0)
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("HasLanded", false);
            print(animator.GetBool("HasLanded"));
        }
    }

    public bool jumpTest()
    {
        return jumpTrue;
    }
}