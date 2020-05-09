using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Torretta : Enemy
{
    private GameObject player;
    Vector2 playerPosition;

    public float radiusDetect=10;

    Vector2 defaultPosition;

    //sparo
    public GameObject bullet;
    public Transform firePoint;
    public float bulletForce=20;

    //delay sparo
    public float delayShoting=0.5f;
    float ShootTimeleft=-5f ;

    void Start()
    {
        base.Start();
        defaultPosition = rb.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        PointAndShoot();

        rb.position = defaultPosition;
    }

    void PointAndShoot()
    {
        firePoint.rotation.Set(0,0,rb.rotation,0);
        playerPosition = player.transform.position;
        Vector2 difference = playerPosition - rb.position;
        rb.rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 180f;
        float distance = Mathf.Sqrt(Mathf.Pow(difference.x, 2) + Mathf.Pow(difference.y, 2));
        if (ShootTimeleft <= 0)
        {
            if (distance < radiusDetect)
                Shoot(difference);
        }
        else
            ShootTimeleft -= Time.deltaTime;
    }

    void Shoot(Vector2 difference)
    {
        GameObject turretBullet = Instantiate(bullet, firePoint.position,this.transform.rotation);
        Rigidbody2D brb = turretBullet.GetComponent<Rigidbody2D>();
        brb.AddForce(firePoint.right*-1*bulletForce, ForceMode2D.Impulse);
        ShootTimeleft = delayShoting;
    }
}
