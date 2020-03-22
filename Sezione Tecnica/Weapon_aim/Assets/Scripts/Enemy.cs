using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth=100;
    int currentHealth;
    public int CurrentHealth {get => currentHealth;}

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth=Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(CurrentHealth + "/" + maxHealth);
    }
}
