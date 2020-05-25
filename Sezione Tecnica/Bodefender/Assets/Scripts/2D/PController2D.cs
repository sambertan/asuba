﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class PController2D : Player
{
    //movement
    public float defaultMovementSpeed;
    public float x;
    public Rigidbody2D rb; 
    public Camera cam;


    //animation
    public Animator animator;

    //Story
    public Image panel;

    //Pause
    public bool paused;
    public Canvas pause_panel;
    public Canvas HUD;
   


    //Higerjump
    public float jumpVelocity;
    public int jump;
    public int maxjump = 2;
    public bool grounded;

    //proiettili
    public static int direction=1;

    //ZA WARUDO
    public AudioSource zawarudo;
    public AudioSource soundtrack;
    public float Volume;

  
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            panel.gameObject.SetActive(false);
       
        Movement_character();
        Direction();
        Pause();
        JumpingAndFalling();

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
      

       
        base.Update();
    }
    void Movement_character()
    {
        if (Input.GetKey(KeyCode.LeftShift) && grounded)
            defaultMovementSpeed = 10f;
        else
            defaultMovementSpeed = 5f;

        x = Input.GetAxis("Horizontal") * defaultMovementSpeed;
        rb.velocity = new Vector2(x, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isJumping", true);
            if (jump > 0)
            {

                //rb.AddForce(Vector3.up * jumpVelocity, ForceMode2D.Impulse);
                if (rb.velocity.y > 0)
                {
                    rb.velocity += new Vector2(0,jumpVelocity);
                }
                else
                {
                     rb.velocity = new Vector2(0, jumpVelocity);
                  
                }
                  
                grounded = false;
                jump = jump - 1;
              
                
            }
            if (jump == 0)
            {

                return;
            }    
        }



        /*
        if(defaultMovementSpeed > 0 && Shooting2D.shooting)
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
       */
    }

    void JumpingAndFalling()
    {
        if (rb.velocity.y >= -0.5f)
        {
            animator.SetBool("isFalling", false);
        }
        else
        {
            animator.SetBool("isFalling", true);
        }
        //controllo su -0.5 per risoluzione di un bug
    }


    void Pause()
    {
        if (paused)
        {
            soundtrack.Pause();
           
            Time.timeScale = 0f;
            pause_panel.gameObject.SetActive(true);
            HUD.gameObject.SetActive(false);
        }
        else
        {
            zawarudo.Play();
            soundtrack.UnPause();
            pause_panel.gameObject.SetActive(false);
            HUD.gameObject.SetActive(true);
            Time.timeScale = 1f;
           
        }
        if (Input.GetKeyDown(KeyCode.Escape))
       paused = !paused;
    }



    void Direction()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {   
            sprite.flipX = false;
            direction = 1;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = true;
            direction = -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJumping", false);
            jump = maxjump;
            grounded = true;

        }
        if (collision.gameObject.tag == "Portal")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (collision.gameObject.tag == "Finish")
            SceneManager.LoadScene(7);
        
    }
   
   
   


}
