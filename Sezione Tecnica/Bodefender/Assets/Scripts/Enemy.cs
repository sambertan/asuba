using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth=100;
    int currentHealth;

    protected Rigidbody2D rb;

    //death
    protected bool isAlive=true;

    //animation
    Animator animator;
    protected SpriteRenderer sprite;

    public int CurrentHealth {get => currentHealth;}
    

    public void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth=Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("Enemy:" + CurrentHealth + "/" + maxHealth);
        if (currentHealth == 0)
            Die();
    }

    void Die()
    {
        animator.SetBool("isAlive", false);   
        isAlive = false;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        collider.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;

        sprite.color = Color.grey;
    }


}
