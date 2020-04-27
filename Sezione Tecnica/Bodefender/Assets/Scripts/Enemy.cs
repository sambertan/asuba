using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth=100;
    int currentHealth;

    Rigidbody2D rb;

    //death
    protected bool isAlive=true;

    //animation
    Animator animator;
    public int CurrentHealth {get => currentHealth;}

    public void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth=Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(CurrentHealth + "/" + maxHealth);
        if (currentHealth == 0)
            Die();
    }

    void Die()
    {
        animator.SetBool("isAlive", false);
        isAlive = false;
    }


}
