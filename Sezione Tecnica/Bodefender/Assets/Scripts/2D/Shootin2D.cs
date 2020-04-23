using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2D : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {   
        firePoint.position.Set(PController2D.direction*firePoint.position.x,firePoint.position.y,firePoint.position.z);
        //Debug.Log(firePoint.position);
        Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);
    }
}
