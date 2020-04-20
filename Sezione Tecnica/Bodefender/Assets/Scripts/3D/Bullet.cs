using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //  public GameObject hitEffect;
    public float speed = 20f;
    public Rigidbody2D rb;


    private void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D collidedElement)
    {
        Enemy collidedScriptE = collidedElement.GetComponent<Enemy>();
        Player collidedScriptP = collidedElement.GetComponent<Player>();

        if (collidedScriptE != null)
        {
            collidedScriptE.ChangeHealth(-2);
        }
        else
            Debug.LogWarning("non nemico");
        
        if (collidedScriptP == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Player");
        }
        

    }

    
}
