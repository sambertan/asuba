using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healShield : MonoBehaviour
{
    public int healing;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.HealArmor(healing);
            Debug.Log("scudato");
        }
    }

}
