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
    protected Animator animator;
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
        {
            if (this.GetType() == typeof(Zubat))
                ZubatDie();
            else
            Die();
        }
            
        
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

    void ZubatDie()
    {
        animator.SetBool("isAlive", false);
        isAlive = false;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = false;
        collider.size = new Vector2(0.01f, 0.01f);
        collider.offset = new Vector2(-0.07952118f, -0.3832827f);
        rb.gravityScale = 1;
    }


}
