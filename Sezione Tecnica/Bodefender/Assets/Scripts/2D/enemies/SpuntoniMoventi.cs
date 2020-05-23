using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpuntoniMoventi : MonoBehaviour
{
    public int damage;
    public float time;
    float timeLeft;
    bool extended;

    SpriteRenderer sprite;
    BoxCollider2D collider;

    private void Start()
    {
        timeLeft = time;
        extended = false;

        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        Debug.Log(timeLeft);
        if (timeLeft < 0)
        {
            extended = !extended;
            if (extended)
            {
                sprite.enabled = true;
                collider.enabled = true;
            }
            else
            {
                sprite.enabled = false;
                collider.enabled = false;
            }
            timeLeft = time;
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.Damage(damage);
        }
    }
}
