using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [Header("Health")]
    public int health = 250;
    public int lowHealth = 75;
    int maxHealth;
    public Text healthNumber;

    [Header("Slider")]
    public Slider healthbar;
    public Image fill;
    public Color lowHealthColor;
    public Color normalHealth;
    public Image background;
    public Color backgroundHealth;
    public Color backgroundLowHealth;

    [Header("Got hit screen")]
    public Image gotHitImage;
    public float gotHitImageVisability = 0.8f;
    public float gotHitImageDissapear = 0.01f;
    bool damageTaken;

    
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthbar.maxValue = maxHealth;
        healthbar.value = maxHealth;
        damageTaken = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthNumber.text = ""+ health;
        healthbar.value = health;

        if (healthbar.value <= lowHealth)
        {
            fill.color = lowHealthColor;
            background.color = backgroundLowHealth;
            healthNumber.color = lowHealthColor;
        }
        else
        {
            fill.color = normalHealth;
            background.color = backgroundHealth;
        }

        if (gotHitImage != null && damageTaken)
        {
            if (gotHitImage.color.a > 0)
            {
                var color = gotHitImage.color;
                color.a -= gotHitImageDissapear;
                gotHitImage.color = color;
            }
        }

        //Allt under här inom Update är bara för att kolla så att koden funkar och ska raderas - EN
        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(20);
        }
    }

    public void TakeHealing(int Healing)
    {   
        health += Healing;
        
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;

        var color = gotHitImage.color;
        color.a = gotHitImageVisability;
        gotHitImage.color = color;

        if (health <= 0)
        {
            damageTaken = false;
            Die();
        }
    }

    public void Die()
    {
        print("Ded");


        var color = gotHitImage.color;
        color.a = 1;
        gotHitImage.color = color;
    }

}
