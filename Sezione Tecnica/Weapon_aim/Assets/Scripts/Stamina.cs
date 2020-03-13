using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider StaminaBar;
    public float MaxStamina;
    public float StaminaLoss;
    public float moveSpeed = 5f;
    void Start()
    {
        StaminaBar.maxValue = MaxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
            MaxStamina -= StaminaLoss * Time.deltaTime;
            StaminaBar.value = MaxStamina;
            if (MaxStamina <= 0)
            {
                moveSpeed = 5;
            }
        }
        
       
       
    }
}
