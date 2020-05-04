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
    //float baseGaObWidth;

    Image reloadAnimationLine;
    Image lineStopper;
    bool rAnimationActive=false;
    float xPerSecond;
    float startingXDiffToStopper;



    private void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting2D>();
        bar = GetComponent<Image>();
        baseWidth = bar.rectTransform.rect.width;
        widthUnit = baseWidth / gun.Maxbullet;

        reloadAnimationLine = GameObject.FindGameObjectWithTag("UI/reloadBar").GetComponent<Image>();
       lineStopper = GameObject.FindGameObjectWithTag("UI/reloadBarStopper").GetComponent<Image>();

        startingXDiffToStopper = Mathf.Abs(lineStopper.gameObject.transform.position.x - reloadAnimationLine.gameObject.transform.position.x);
    }

    public void SetBarSizeShoot()
    {
        bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, gun.Bulletsleft * widthUnit);
    }

    private void FixedUpdate()
    {
        if (rAnimationActive)
        {
            reloadAnimationLine.gameObject.transform.position = new Vector3(reloadAnimationLine.gameObject.transform.position.x + xPerSecond * Time.deltaTime, reloadAnimationLine.gameObject.transform.position.y);
            if (reloadAnimationLine.gameObject.transform.position.x >= lineStopper.gameObject.transform.position.x)
                ReloadAnimationEnds();
        }
    }

    public void ReloadAnimationStart(float animationtime)
    {
        xPerSecond =startingXDiffToStopper / animationtime;
        reloadAnimationLine.enabled = true;
        rAnimationActive = true;
    }

    public void ReloadAnimationEnds()
    {
        reloadAnimationLine.enabled = false;
        rAnimationActive = false;
        Vector3 standardPos = new Vector3(reloadAnimationLine.gameObject.transform.position.x - startingXDiffToStopper, reloadAnimationLine.gameObject.transform.position.y, reloadAnimationLine.gameObject.transform.position.z);
        reloadAnimationLine.gameObject.transform.position = standardPos;
            Debug.Log("dovrebbe essere" + new Vector2(reloadAnimationLine.gameObject.transform.position.x - startingXDiffToStopper, reloadAnimationLine.gameObject.transform.position.y));
        Debug.Log("è" + reloadAnimationLine.gameObject.transform.position);
    }
}
