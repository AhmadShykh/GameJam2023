using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    public void TakeDamage(float v)
    {
        currentHealth -= v;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    public void healup(float v)
    {
        if(currentHealth >= MaxHealth) { 
        }
        else
        {
            currentHealth += v;
        }
    }
}
