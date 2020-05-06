using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int maxShield = 10;
    protected int actualHealth;
    protected int actualShield;
    public float damageImmunityTime=3;
    protected float damageTimeLeft=0;

    public int Actualscene;
    public static int DeathScene = 0;

    public int ActualHealth { get => actualHealth; }
    public int ActualShield { get => actualShield; }

    //Blinking and sprite management
    public float blinkingGapS = 0.2f;
    float blinkingleft;
    public Color BlinkingColor;
    protected SpriteRenderer sprite;
    bool ended;

    //keys and doors
    List<Color> keys = new List<Color>();

    protected void Start()
    {

       
        actualHealth = maxHealth;
        actualShield = maxShield;
        actualShield = 0;
        Actualscene = SceneManager.GetActiveScene().buildIndex;
        
        sprite = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        if (damageTimeLeft > 0)
        {
            damageTimeLeft -= Time.deltaTime;
            if (blinkingleft > 0)
                blinkingleft -= Time.deltaTime;
            else
            {
                ChangeBlink();
                blinkingleft = blinkingGapS;
            }
        }
        else if (!ended)
        {
            ended = true;
            sprite.color = Color.white;
        }
    }


    public void Damage(int amount)
    {
        if (amount < 1) return;
        if (damageTimeLeft > 0) return;
        else if (actualShield > 0)
        {
            int oldShield = actualShield;
            actualShield = Mathf.Clamp(actualShield - amount, 0, maxShield);
            if (actualShield == 0)
                Damage(Mathf.Abs(oldShield - amount));
        }
        else
        {
            actualHealth = Mathf.Clamp(actualHealth - amount, 0, maxHealth);
            if(actualHealth == 0)
            {
                DeathScene = Actualscene;
                SceneManager.LoadScene(6);
            }
        }
        damageTimeLeft = damageImmunityTime;
        blinkingleft = blinkingGapS;
        ChangeBlink();
        ended = false;
    }

    public void HealLife(int amount)
    {
        if (amount < 1) return;
        actualHealth = Mathf.Clamp(actualHealth + amount, 0, maxHealth);
    }

    public void HealArmor(int amount)
    {
        if (amount < 1) return;
        actualShield = Mathf.Clamp(actualShield + amount, 0, maxShield);
    }


    public void Addkey(Color KeyC)
    {
        keys.Add(KeyC);
    }

    public bool UseKey(Color KeyC)
    {
        bool contains=false;
        foreach(var e in keys)
        {
            contains = (e == KeyC);
            if (contains)
                break;
        }
        if(contains)
        {
            keys.Remove(KeyC);
        }
        return contains;
    }

    #region privates

    void ChangeBlink()
    {
        if (sprite.color == new Color(255, 255, 255))
            sprite.color = BlinkingColor;
        else
            sprite.color = new Color(255, 255, 255);
    }

   

    #endregion
}
