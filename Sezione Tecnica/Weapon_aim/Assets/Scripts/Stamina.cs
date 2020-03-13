using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider StaminaBar;
    public float MaxStamina;
    public float StaminaLoss;
    public float StaminaGain;
    public float moveSpeed = 5f;
    void Start()
    {
        StaminaBar.maxValue = MaxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        MaxStamina = Mathf.Abs(MaxStamina); //ritorna sempre il valore assoluto
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
            MaxStamina -= StaminaLoss * Time.deltaTime;
            StaminaBar.value = MaxStamina;
        }
        else
        {
            moveSpeed = 5f;
            MaxStamina += StaminaGain * Time.deltaTime;
            StaminaBar.value = MaxStamina;
        }
       
    }
}
