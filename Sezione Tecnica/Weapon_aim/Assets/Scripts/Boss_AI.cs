using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;

    public Animator redPanel;
    public Animator camAnim;
    public Slider healthBar;

    // Update is called once per frame
    void Update()
    {
        if(timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }
    }
}
