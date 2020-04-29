using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    int direction;

    public float shotLenght;
    Vector2 StartingPosition;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = PController2D.direction;
        rb.velocity = new Vector2(speed * direction, 0);
        StartingPosition = rb.position;
    }
    void OnTriggerEnter2D(Collider2D collidedElement)
    {
        Enemy collidedScriptE = collidedElement.GetComponent<Enemy>();
        Player collidedScriptP = collidedElement.GetComponent<Player>();

        if (collidedElement.gameObject.CompareTag("collectible"))
            return;

        if (collidedScriptE != null)
        {
            collidedScriptE.ChangeHealth(-2);
        }

        if (collidedScriptP == null)
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        //check on distance
        float distance = Mathf.Sqrt(Mathf.Pow(rb.position.x - StartingPosition.x, 2f) + Mathf.Pow(rb.position.y - StartingPosition.y, 2));
        if (distance > shotLenght)
            Destroy(this.gameObject);
    }


}
