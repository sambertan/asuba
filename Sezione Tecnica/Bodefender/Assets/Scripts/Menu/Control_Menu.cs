using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control_Menu : MonoBehaviour
{
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        Blinking();
    }
    void Update()
    {
     if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator Blink()
    {
        while(true)
        {
            switch(image.color.a.ToString())
            {
                case "0":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                    yield return new WaitForSeconds(0.7f);
                    break;
                case "1":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                    yield return new WaitForSeconds(0.7f);
                    break;
            }
            
        }
    }
    void Blinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }
}
