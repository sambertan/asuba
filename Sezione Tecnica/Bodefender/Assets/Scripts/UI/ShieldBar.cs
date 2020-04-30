using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Sprite[] status = new Sprite[10];
    Image SpriteSImage;
    Player player;

    private void Start()
    {
        SpriteSImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        SpriteSImage.sprite = status[player.ActualShield];

        //if (player.ActualHealth == 0)
        //    SpriteSImage.enabled = false;
        //else
        //{
        //    SpriteSImage.enabled = true;
        //    SpriteSImage.sprite = status[player.ActualHealth];
        //}
    }
}
