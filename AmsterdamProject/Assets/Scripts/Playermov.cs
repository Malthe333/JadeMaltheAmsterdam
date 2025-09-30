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

    public UnityEvent OnLevelComplete;

    private Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        InAir = false;
       
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
        
    }

    void Update() {

        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(moveHorizontal * speed, rb2d.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (InAir == false)
            {
                rb2d.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
            }
        }
    }

}