using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zubat : Enemy
{
    public float velocità=5;
    public Vector2[] checkpoints;

    int currentpoint=0;
    int maxpoint;
    bool backward;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxpoint = checkpoints.Length - 1;
        backward = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, checkpoints[currentpoint], velocità * Time.deltaTime);

        if (Vector2.Distance(transform.position, checkpoints[currentpoint]) < 0.1f)
        {
            if (backward)
                currentpoint--;
            else
                currentpoint++;
        }
        if (currentpoint > maxpoint)
        {
            currentpoint--;
            backward = true;
        }
        else if (currentpoint < 0)
        {
            currentpoint++;
            backward = false;
        }

    }
}
