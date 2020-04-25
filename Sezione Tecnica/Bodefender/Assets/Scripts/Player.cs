using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int maxShield = 10;
    protected int actualHealth;
    protected int actualShield;
    public float damageImmunityTime=3;
    protected float damageTimeLeft=0;

    public Vector3 spawnPoint;

    public int ActualHealth { get => actualHealth; }
    public int ActualShield { get => actualShield; }

    protected void Start()
    {
        spawnPoint = transform.position;

        actualHealth = maxHealth;
        //actualShield = maxShield;
        Debug.Log($"lifePlayer:{actualHealth}/{maxHealth}");
    }

    protected void Update()
    {
        if (damageTimeLeft > 0)
        {
            damageTimeLeft -= Time.deltaTime;
        }
    }


    public void Damage(int amount)
    {
        if (amount < 1) return;
        if (damageTimeLeft > 0) return;
        else if (actualShield > 0)
        {
            int oldShield = actualShield;
            actualShield = Mathf.Clamp(actualShield - amount, 0, maxShield);
            if (actualShield == 0)
                Damage(Mathf.Abs(oldShield - amount));
        }
        else
        {
            actualHealth = Mathf.Clamp(actualHealth - amount, 0, maxHealth);
            if(actualHealth == 0)
            {
                Die();
            }
            Blink();
        }
        Debug.Log($"lifePlayer:{actualHealth}/{maxHealth}");
        damageTimeLeft = damageImmunityTime;
        
    }

    public void HealLife(int amount)
    {
        if (amount < 1) return;
        actualHealth = Mathf.Clamp(actualHealth + amount, 0, maxHealth);
    }

    public void HealArmor(int amount)
    {
        if (amount < 1) return;
        actualShield = Mathf.Clamp(actualShield + amount, 0, maxShield);
        Debug.Log($"Curato lifePlayer:{actualHealth}/{maxHealth}");
    }

    public void Die()
    {
        actualHealth = maxHealth;
        transform.position = spawnPoint;
    }

    #region privates

    public void Blink()
    {
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        Thread blinking = new Thread(() =>
        {
            for(int i = 0; i<15; i++)
            {
                sprite.color = new Color(242, 255, 85);
                Thread.Sleep(3000 / 15);
                sprite.color = new Color(0, 0, 0);
                Thread.Sleep(3000 / 15);
            }
            sprite.color = new Color(0, 0, 0);
        });

        blinking.Start();
        
    }

    #endregion
}
