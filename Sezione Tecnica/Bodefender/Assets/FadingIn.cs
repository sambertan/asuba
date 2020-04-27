using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingIn : MonoBehaviour
{
    public Image whiteFade;
    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(0.0f);
        fade();
    }

    // Update is called once per frame
    void fade()
    {
        whiteFade.CrossFadeAlpha(1, 2, false);
    }
}
