using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2D : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float reloadTime=3;
    public float reloadLeft;
    bool alreadyReloaded=true;

    int maxbullet = 10;
    public int bulletsleft;

        
    private void Start()
    {
        bulletsleft = maxbullet;
    }

    void Update()
    {
        if (reloadLeft > 0)
        {
            reloadLeft -= Time.deltaTime;
        }
        else if(!alreadyReloaded)
        {
            alreadyReloaded = true;
            bulletsleft = maxbullet;
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && bulletsleft > 0)
            {
                Shoot();
                bulletsleft--;
            }
            if (Input.GetKeyDown(KeyCode.R) && bulletsleft < maxbullet)
            {
                reload();
            }
        }
         
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);
    }

    void reload()
    {
        reloadLeft = reloadTime;
        alreadyReloaded = false;
    }
}
