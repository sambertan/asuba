using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_AI : Enemy
{
    //health in mother-class

    public int damage;
    private float timeBtwDamage = 1.5f;

    public Animator redPanel;
    public Animator camAnim;
    public Slider healthBar;

    void Update()
    {
        if(timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }
    }
}
