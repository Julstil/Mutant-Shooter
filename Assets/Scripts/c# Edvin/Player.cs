using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 250;
    int maxHealth;
    Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthbar.maxValue = maxHealth;
        healthbar.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }

}
