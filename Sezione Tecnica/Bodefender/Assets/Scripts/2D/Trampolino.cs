using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolino : MonoBehaviour
{
    public float pushingForce;
    public bool alto;
    public bool basso;
    public bool sinistra;
    public bool destra;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D r = collision.GetComponent<Rigidbody2D>();

        Debug.Log("trampolino attivato");

        if (alto)
        {
            r.velocity=new Vector2(0, pushingForce);
        }
        if (basso)
        {
            r.velocity = new Vector2(0, -pushingForce);
        }
        if (destra)
        {
            r.velocity = new Vector2(pushingForce,0);
        }
        if (sinistra)
        {
            r.velocity = new Vector2(-pushingForce, 0);
        }
        
    }
}
