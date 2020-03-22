using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  //  public GameObject hitEffect;
    void OnTriggerEnter2D(Collider2D collidedElement)
    {
        Enemy collidedScript = collidedElement.GetComponent<Enemy>();

        if (collidedScript != null)
        {
            collidedScript.ChangeHealth(-2);
        }
        else
            Debug.LogWarning("non nemico");
        
        Destroy(gameObject);
    }

    
}
