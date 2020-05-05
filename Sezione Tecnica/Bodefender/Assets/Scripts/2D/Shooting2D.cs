using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2D : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int shootingFrames;

    //Animation
   public Animator animator;


    //reloading
    public float reloadTime = 3;
    public float reloadLeft;
    bool alreadyReloaded = true;


    //shootingCounter
    readonly int maxbullet = 10;
    int bulletsleft;

    //BulletsBar
    BulletsBar bulletsBar;

    public int Bulletsleft { get => bulletsleft; }
    public int Maxbullet { get => maxbullet; }

    private void Start()
    {
        bulletsBar = GameObject.FindGameObjectWithTag("UI / BulletsBar").GetComponent<BulletsBar>();
        bulletsleft = maxbullet;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (shootingFrames > 0)
            shootingFrames--;
        else
            animator.SetBool("isShooting", false);


        if (reloadLeft > 0)
        {
            reloadLeft -= Time.deltaTime;
        }
        else if (!alreadyReloaded)
        {
            alreadyReloaded = true;
            bulletsleft = maxbullet;
            bulletsBar.SetBarSizeShoot();
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && bulletsleft > 0)
            {
                shootingFrames = 12;
                animator.SetBool("isShooting", true);
                Shoot();
                
              
            }
            if (Input.GetKeyDown(KeyCode.R) && bulletsleft < maxbullet)
            {
                reload();
            }
        }
        //animator.SetBool("isShooting", shooting);
    }

    void Shoot()
    {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletsleft--;
            bulletsBar.SetBarSizeShoot();
    }

    void reload()
    {
        reloadLeft = reloadTime;
        alreadyReloaded = false;
        bulletsBar.ReloadAnimationStart(reloadTime);
    }
}
