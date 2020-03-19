using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;

public class Stamina : MonoBehaviour
{
    static public bool running = false;
    static public bool canRun = true;

    public Slider staminaBar;
    public float maxStamina=100;
    public float actualStamina = 100;
    public float staminaLoss=20;
    public float staminaGain=20;
    public static int preRechargeTime = 2000;

    public Thread coolThread;

    void Start()
    {
        staminaBar.maxValue = maxStamina;
        coolThread = new Thread(threadCoolDown);
    }

    // Update is called once per frame
    void Update()
    {
        if (running && actualStamina > 0)
        {
            actualStamina -= staminaLoss * Time.deltaTime;
            staminaBar.value = actualStamina;
            if (actualStamina < 0)
            {
                canRun = false;
                if (!coolThread.IsAlive)
                {
                    coolThread.Start();
                }
            }
        }
        else if (actualStamina < maxStamina  && !coolThread.IsAlive)
        {
            actualStamina += staminaGain * Time.deltaTime;
            staminaBar.value = actualStamina;
            if (actualStamina > maxStamina / 5)
            {
                canRun = true;
            }
            coolThread = new Thread(threadCoolDown); //reinstanzia il trhead per permettere di richiamare più volte il metodo
        }

    }

    static void threadCoolDown()
    {
        Thread.Sleep(preRechargeTime);
    }
}
