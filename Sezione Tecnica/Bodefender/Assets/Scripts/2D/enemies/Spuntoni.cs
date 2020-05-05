using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spuntoni : MonoBehaviour
{
    public int damage;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player!=null)
        {
            player.Damage(damage);
        }
        
    }


}
