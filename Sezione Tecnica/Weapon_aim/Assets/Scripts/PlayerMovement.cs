using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  //imposta la velocità
    public Rigidbody2D rb; //riferimento al rigidbody
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }
    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");    //imposta A/D/<-/-> per muoversi a destra e sinistra
        movement.y = Input.GetAxisRaw("Vertical");   //imposta S/W/freccia in su e in giu per muoversi su e giu

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 10f;
        else
            moveSpeed = 5f;
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
    void Update()
    {
        Movement();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);        
    }
   private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position; //fa in modo che possiamo ottenere il punto da cui parte il colpo grazie alla sottrazione dei vettori
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //Athan2 consiste in una variazione dell'arcotangente(Vedere su wikipedia per spiegazione)
        rb.rotation = angle;
    }

  
}
