using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBackAndForth : Enemy
{
    public float speed;
    public float time;
    float timeleft;
    public bool moveRight;
    public int dannoContatto;
    public Animator animator;
    SpriteRenderer sprite;

    


    void Update()
    {
        if (isAlive)
        {
            timeleft = timeleft - Time.deltaTime;
            if (timeleft <= 0)
            {
                timeleft = time;
                moveRight = !moveRight;
                sprite.flipX = !sprite.flipX;
            }
            if (moveRight)
            {
                transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            }
            else
            {
                transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            }
        }
    }

    private void Start()
    {
        timeleft = time;
        sprite = GetComponent<SpriteRenderer>();
        base.Start();
    }

    private void OnCollisionEnter2D(Collision2D Oggetto)
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
        this.timeleft = time - timeleft;
        moveRight = !moveRight;
        sprite.flipX = !sprite.flipX;
    }

}
