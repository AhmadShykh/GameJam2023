using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    public void TakeDamage(int v)
    {
        currentHealth -= v;
        healthBar.SetHealth(currentHealth);
        if(currentHealth==0)
        {
            Destroy(gameObject);
        }
    }
}
