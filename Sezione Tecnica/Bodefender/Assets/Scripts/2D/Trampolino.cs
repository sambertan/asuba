using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolino : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trampolino attivato");
        Rigidbody2D r = collision.GetComponent<Rigidbody2D>();
        var v =new Vector2(0, 600);
        r.AddForce(v);
    }
}
