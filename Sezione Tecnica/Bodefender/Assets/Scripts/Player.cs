using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int maxShield = 10;
    protected int actualHealth;
    protected int actualShield;
    public float damageImmunityTime=3;
    protected float damageTimeLeft=0;
    public Vector3 Spawn;
    public int ActualHealth { get => actualHealth; }
    public int ActualShield { get => actualShield; }

    protected void Start()
    {
        Spawn = transform.position;
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
                actualHealth = maxHealth;
                transform.position = Spawn;
            }
        }
        Debug.Log($"lifePlayer:{actualHealth}/{maxHealth}");
        damageTimeLeft = damageImmunityTime;
        
    }

    public void HealLife(int amount)
    {
        if (amount < 1) return;
        actualHealth = Mathf.Clamp(actualHealth - amount, 0, maxHealth);
    }

    public void HealArmor(int amount)
    {
        if (amount < 1) return;
        actualShield = Mathf.Clamp(actualShield - amount, 0, maxShield);
    }
}
