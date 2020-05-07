using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcchioAI : Enemy
{
    //to track the player a interact with it
    Transform target;
    public float speed = 10;
    public float viewRange = 15;
    public float shootingRange = 8;
    float distance;
    float distancex;
    float distancey;

    //to move the sprite
    SpriteRenderer sprite;
    bool direction;

    //to jump
    Rigidbody2D rb;
    public float jumpRechargeTime;
    float jumpTimeLeft;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        distancex = transform.position.x - target.position.x;
        direction = Mathf.Sign(distancex) == 1;
        distancex = Mathf.Abs(distancex);

        distancey = target.position.y - transform.position.y;

        distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));

        sprite.flipX = !direction;

        if (distance <= viewRange && distance >= shootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            if (distancey < 5.4f && distancey > 1.6f)
                Jump();
        }

        else if (distance <= shootingRange)
        {
            if (distancey < 5.4f && distancey > 1.6f)
                Jump();

            distancey = target.position.y - transform.position.y;


            if (distancey < 1.6f)
                Shoot();
        }




        jumpTimeLeft -= Time.deltaTime;
    }

    private void Jump()
    {
        if (jumpTimeLeft <= 0)
        {
            jumpTimeLeft = jumpRechargeTime;
            rb.velocity += new Vector2(0, 8);
            Debug.Log("jumpato");
        }
    }

    void Shoot()
    {
        //Debug.Log("Pew Pew Pew");
    }
}
