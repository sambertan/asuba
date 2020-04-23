using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healHealth : MonoBehaviour
{
    public int healing;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.HealLife(healing);
            Debug.Log("curato");
        }
    }
}
