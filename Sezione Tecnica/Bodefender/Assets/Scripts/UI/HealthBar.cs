using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite[] status = new Sprite[11];
    Image SpriteSImage;
    Player player;

    private void Start()
    {
        SpriteSImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        SpriteSImage.sprite = status[player.ActualHealth-1];
    }


}
