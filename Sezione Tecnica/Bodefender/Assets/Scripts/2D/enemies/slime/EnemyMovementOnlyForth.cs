using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementOnlyForth : Enemy
{
    public float speed;
    public bool moveRight;
    public int dannoContatto;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (moveRight) sprite.flipX = !sprite.flipX;
        base.Start();
    }


    void Update()
    {
        if (!isAlive)
            return;

        if (moveRight)
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D Oggetto) //il nemico continuerà a moversi in avanti e cambierà direzione solo se sbatterà contro un muro.   
    {

        Player Giocatore = Oggetto.collider.GetComponent<Player>();
        Terrain terreno = Oggetto.collider.GetComponent<Terrain>();
        if (terreno != null)
        {
            return;
        }
        if (Giocatore != null)
        {
            Giocatore.Damage(dannoContatto);
        }
        else
        {
            moveRight = !moveRight;
            sprite.flipX = !sprite.flipX;
        }

    }
}
