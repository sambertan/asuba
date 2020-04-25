using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PController2D : Player
{
    //movement
    public float defaultMovementSpeed = 5f;  
    public float runMultipler = 2;
    public Rigidbody2D rb; 
    public Camera cam;


    //double-jump
    public float jumpVelocity;
    private bool Grounded;
    public Transform gCheck;
    public float Radius = 0.6f;
    public LayerMask Ground;


    //sprite
    private SpriteRenderer sprite;

    //proiettili
    public static int direction;

   
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
        sprite = GetComponent<SpriteRenderer>();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

       
        Movement_character();
        Direction();
       
      

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        base.Update();
    }
    void Movement_character()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float movementSpeed = defaultMovementSpeed;
            movementSpeed *= runMultipler;
        }
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0f );
        transform.Translate( movement * Time.deltaTime * defaultMovementSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode2D.Impulse);
            Grounded = false;
        }
        Grounded = Physics2D.OverlapCircle(gCheck.position, Radius, Ground);
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
    


}
