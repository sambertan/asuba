using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int maxShield = 10;
    protected int actualHealth;
    protected int actualShield;

    public int ActualHealth { get => actualHealth; }
    public int ActualShield { get => actualShield; }

    private void Start()
    {
        actualHealth = maxHealth;
        actualShield = maxShield;
    }


    public void Damage(int amount)
    {
        if (amount < 1) return;
        else if (actualShield > 0)
        {
            int oldShield = actualShield;
            actualShield = Mathf.Clamp(actualShield - amount, 0, maxShield);
            if(actualShield==0)
            Damage(Mathf.Abs(oldShield - amount));
        }
        else
        {
            actualHealth = Mathf.Clamp(actualHealth - amount, 0, maxHealth);
        }
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
