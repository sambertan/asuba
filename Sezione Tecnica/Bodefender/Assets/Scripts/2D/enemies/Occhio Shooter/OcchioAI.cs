using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcchioAI : MonoBehaviour
{
    Transform target;
    public float speed=10;
    public float viewRange = 15;
    public float shootingRange = 8;
    float distance;

    SpriteRenderer sprite;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - target.position.x, 2) + Mathf.Pow(transform.position.y - target.position.y, 2));
        if (distance <= viewRange && distance >= shootingRange)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        else if (distance <= shootingRange&& (target.position.y-transform.position.y) <2.7f)
            Shoot();




    }

    void Shoot()
    {
        Debug.Log("Pew Pew Pew");
    }
}
