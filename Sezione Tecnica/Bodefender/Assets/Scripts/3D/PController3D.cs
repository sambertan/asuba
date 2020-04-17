using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PController3D : Player
{
    public float defaultMovementSpeed = 5f;  //imposta la velocità
    public float runMultipler = 2;
    public Rigidbody2D rb; //riferimento al rigidbody
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    


    void Update()
    {
       
        float movementSpeed = defaultMovementSpeed;

        Movement();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetKey(KeyCode.LeftShift) && Stamina.canRun)
        {
            movementSpeed *= runMultipler;
            Stamina.running = true;
        }
        else
        {
            Stamina.running = false;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }

        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position; //fa in modo che possiamo ottenere il punto da cui parte il colpo grazie alla sottrazione dei vettori
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //Athan2 consiste in una variazione dell'arcotangente(Vedere su wikipedia per spiegazione)
        rb.rotation = angle;
    }

    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");    //imposta A/D/<-/-> per muoversi a destra e sinistra
        movement.y = Input.GetAxisRaw("Vertical");   //imposta S/W/freccia in su e in giu per muoversi su e giu
    }

    
    

  
}


