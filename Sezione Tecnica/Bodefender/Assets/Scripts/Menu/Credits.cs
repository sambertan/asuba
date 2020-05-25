using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    void Start()
    {
        StartCoroutine(SetCredits());
    }

    // Update is called once per frame
   public IEnumerator SetCredits()
    {
        
        yield return new WaitForSeconds(3f);
        a.gameObject.SetActive(false);
        b.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        b.gameObject.SetActive(false);
        c.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        c.gameObject.SetActive(false);
        d.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        d.gameObject.SetActive(false);
        SceneManager.LoadScene(1);



    }
}
