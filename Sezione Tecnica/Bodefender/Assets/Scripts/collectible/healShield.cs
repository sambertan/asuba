using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healShield : MonoBehaviour
{
    public int healing=1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            if(player.ActualShield<player.maxShield)
            {
                player.HealArmor(healing);
                Destroy(this.gameObject);
            }
        }
    }

}
