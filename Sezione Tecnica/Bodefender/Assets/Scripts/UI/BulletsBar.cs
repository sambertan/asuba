using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsBar : MonoBehaviour
{
    Shooting2D gun;
    Image bar;
    float baseWidth;
    float widthUnit;


    private void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting2D>();
        bar = GetComponent<Image>();
        baseWidth = bar.rectTransform.rect.width;
        widthUnit = baseWidth / gun.Maxbullet;
    }

    public void SetBarSizeShoot()
    {
        bar .rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,gun.Bulletsleft * widthUnit);   
    }
}
