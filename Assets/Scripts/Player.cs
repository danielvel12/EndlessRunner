using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; 
    [SerializeField] float jumpForce = 5; 
    [SerializeField] Transform raycastOrigin; 
    [SerializeField] bool isGrounded; 
    bool jump; 
    [SerializeField] Animator anim; 
    float lastYPos; 

    private void Start()
    {
        lastYPos = transform.position.y; 
    }

    void Update()
    {
        CheckForInput();  
        CheckIfPlayerIsFalling(); 
    }

    void FixedUpdate()
    {
        CheckForGrounded(); 
        CheckForJump(); 
    }

    void CheckForJump()
    {
        if(jump == true)
        {
            jump = false; 
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void CheckIfPlayerIsFalling()
    {
        if(transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
        }

        lastYPos = transform.position.y;
    }

    void CheckForInput()
    {
        if(isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jump = true; 
                anim.SetTrigger("Jump"); 
            }
        }
    }

    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down); 
        if(hit.collider != null)
        {
            if(hit.distance < 0.1f)
            {
                isGrounded = true; 
                anim.SetBool("IsGround", true); 
            }
            Debug.Log(hit.transform.name);
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green); 
        }
        else
            { 
                isGrounded = false;
                anim.SetBool("IsGround", false);  
            }
    }
}
