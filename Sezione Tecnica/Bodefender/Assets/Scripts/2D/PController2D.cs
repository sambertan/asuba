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
    private bool Grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatsIsGround;
    public int extrajump;
    public int extrajumpValue;

    //sprite
    private SpriteRenderer sprite;

    //proiettili
    public static int direction;

   
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extrajump = extrajumpValue;
        sprite = GetComponent<SpriteRenderer>();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position , checkRadius , WhatsIsGround);  
       // Grounded = true;
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
        if(Grounded == true)
        {
            extrajump = extrajumpValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extrajump > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            extrajump--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extrajump == 0 && Grounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0f );
        transform.Translate( movement * Time.deltaTime * defaultMovementSpeed);
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
