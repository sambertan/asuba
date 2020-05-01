using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    

    //Higerjump
    public float jumpVelocity;
    public int jump;
    public int maxjump = 2;
    public bool grounded;
    //proiettili
    public static int direction;

   
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {

       
        Movement_character();
        Direction();
       

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
      

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
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
               
                rb.AddForce(Vector3.up * jumpVelocity, ForceMode2D.Impulse);
                grounded = false;
                jump = jump - 1;
              
                
            }
            if(jump == 0)
            {
                
                return;
            }


                
       }

        if(defaultMovementSpeed > 0 && Shooting2D.shooting)
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
       
    }
    

   

    void Onlanding()
    {
        animator.SetBool("isJumping", false);
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
    }



}
