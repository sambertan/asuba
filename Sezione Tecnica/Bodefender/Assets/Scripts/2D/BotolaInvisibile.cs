using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotolaInvisibile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.ToString());
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.ToString());
        Destroy(this.gameObject);
    }
}
