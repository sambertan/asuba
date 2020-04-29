using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    public int damage;

    public float shotLenght = 10;
    Vector2 StartingPosition;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartingPosition = rb.position;
    }

    void OnTriggerEnter2D(Collider2D collidedElement)
    {
        Enemy collidedScriptE = collidedElement.GetComponent<Enemy>();
        Player collidedScriptP = collidedElement.GetComponent<Player>();

        if (collidedElement.gameObject.CompareTag("collectible"))
            return;

        if (collidedScriptP != null)
        {
            collidedScriptP.Damage(damage);
            Debug.Log("player Colpito");
            Destroy(gameObject);
        }
        else if (collidedScriptE == null)
        {
            Destroy(gameObject);
        }


    }

    private void Update()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(rb.position.x - StartingPosition.x, 2f) + Mathf.Pow(rb.position.y - StartingPosition.y, 2));
        if (distance > shotLenght)
            Destroy(this.gameObject);
    }
}
