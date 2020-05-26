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
    public float shootingRange = 6;
    float distance;
    float distancex;
    float distancey;

    //to move the sprite
    bool directionRight;

    //to jump
    public float jumpRechargeTime;
    float jumpTimeLeft;
    bool alreadyJumped;

    //shooting
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float reloadTime;
    float reloadTimeLeft;


    new void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        base.Start();
    }


    void Update()
    {
        if (CurrentHealth == 0)
        {
            Destroy(this.gameObject);
        }
        if (!isAlive)
            return;

        distancex = transform.position.x - target.position.x;
        directionRight = Mathf.Sign(distancex) == 1;
        distancex = Mathf.Abs(distancex);

        distancey = target.position.y - transform.position.y;

        distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));

        sprite.flipX = !directionRight;

        if (distance <= viewRange && distancex >= shootingRange)
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


        if (jumpTimeLeft > 0)
            jumpTimeLeft -= Time.deltaTime;
        if (reloadTimeLeft > 0)
            reloadTimeLeft -= Time.deltaTime;
       
    }

    private void Jump()
    {
        if (jumpTimeLeft <= 0 && !alreadyJumped)
        {
            alreadyJumped = true;
            jumpTimeLeft = jumpRechargeTime;
            rb.velocity += new Vector2(0, 8);
            Debug.Log("jumpato");
        }
    }

    void Shoot()
    {
        if (reloadTimeLeft <= 0)
        {
            animator.Play("Occhio_Shooting");
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
            if (directionRight)
                brb.AddForce(new Vector2(-20, 0), ForceMode2D.Impulse);
            else
                brb.AddForce(new Vector2(20, 0), ForceMode2D.Impulse);
            reloadTimeLeft = reloadTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            alreadyJumped = false;
    }
}
