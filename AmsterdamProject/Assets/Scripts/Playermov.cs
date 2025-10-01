using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Playermov : MonoBehaviour {

    public float speed = 100f;
    public float JumpHeight;
    public bool InAir = false;

    public GameManager gameManager;

    public Animator animator;

    public UnityEvent OnLevelComplete;

    private Rigidbody2D rb2d;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        InAir = false;
        animator.SetBool("IsInAir", false);
        animator.SetTrigger("FinishedJump");
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Finish")
        {
            gameManager.StopTimer();
        }
        


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        InAir = true;
        animator.SetBool("IsInAir", true);
        
    }

    void Update() {

        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(moveHorizontal * speed, rb2d.linearVelocity.y);


        // if the player is falling then an animator bool is set to true
        if (rb2d.linearVelocity.y < 0 && InAir == true)
        {
            animator.SetBool("IsDown", true);
            animator.SetBool("IsUp", false);
        }
        else if (rb2d.linearVelocity.y > 0 && InAir == true)
        {
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", true);
        }
        else
        {
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
        }
        

        if (moveHorizontal > 0f)
        {
            animator.SetBool("IsRunning", true);
            spriteRenderer.flipX = false;

        }
        else if (moveHorizontal < 0f)
        {
            animator.SetBool("IsRunning", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (InAir == false)
            {
                rb2d.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
            }
        }
    }

}