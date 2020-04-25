    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healHealth : MonoBehaviour
{
    public int healing=1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            if (player.ActualHealth < player.maxHealth)
            {
                Debug.Log("curato in teoria");
                player.HealLife(healing);
                Destroy(this.gameObject);
            }
        }
    }
}
