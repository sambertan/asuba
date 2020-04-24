using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torretta : Enemy
{
    public GameObject player;
    Vector2 playerPosition;

    public float radiusDetect=10;

    Rigidbody2D rb;
    Vector2 defaultPosition;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultPosition = rb.position;

        base.Start();
    }

    
    void Update()
    {
        AngleSet();

        rb.position = defaultPosition;

        
    }

    void AngleSet()
    {
        playerPosition = player.transform.position;
        Vector2 difference = playerPosition - rb.position;
        rb.rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 180f;
        float distance = Mathf.Sqrt(Mathf.Pow(difference.x, 2) + Mathf.Pow(difference.y, 2));
        if (distance < radiusDetect)
            Debug.Log("pew!");

        
    }

    void Shoot()
    {

    }
}
