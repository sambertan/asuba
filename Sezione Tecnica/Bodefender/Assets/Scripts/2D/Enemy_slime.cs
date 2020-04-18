using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_slime : MonoBehaviour
{
    public float speed;
    public float time = 3;
    float timeleft;
    public bool Moveright;
    void Update()
    {
        timeleft = timeleft - Time.deltaTime;
        if(timeleft <= 0)
        {
            timeleft = time;
            Moveright = !Moveright;
        }
        if (Moveright)
        {
            transform.Translate(1 * Time.deltaTime * speed,0,0);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
        }
        
    }

    private void Start()
    {
        timeleft = time;
    }

    //In caso di scalini
     private void OnTriggerEnter2D(Collider2D Oggetto)
     {
         //if(Oggetto.gameObject.CompareTag("IWall"))
         if (Oggetto.GetComponent<Player>())
         {
            Moveright = !Moveright;
         }
     }
     
}
