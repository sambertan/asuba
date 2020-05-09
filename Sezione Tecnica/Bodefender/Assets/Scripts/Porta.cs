using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    Color keyColor;
    public Sprite openDoorSprite;

    void Start()
    {
        keyColor = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (collision.gameObject.GetComponent<Player>().UseKey(keyColor))
            {
                Open();
            }
        }
    }

    private void Open()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = openDoorSprite;
        Destroy(gameObject);
    }


}
