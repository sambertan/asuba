using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Color keyColor;

    private void Start()
    {
        keyColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.Addkey(keyColor);
            Destroy(gameObject);
        }
    }

}
