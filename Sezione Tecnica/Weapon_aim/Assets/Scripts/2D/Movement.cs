using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float defaultMovementSpeed = 5f;  
    public float runMultipler = 2;
    public Rigidbody2D rb; 
    public Camera cam;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement_character();

    }
    void Movement_character()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            defaultMovementSpeed *= runMultipler;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        movement.x = Input.GetAxisRaw("Horizontal");
    }
}
