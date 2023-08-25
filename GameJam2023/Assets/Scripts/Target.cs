using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
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
            if (audioSource != null)
            {
                audioSource.Play();
            }
            Destroy(transform.gameObject);
            FinishLevel Finishing = GameObject.FindGameObjectWithTag("Finish").GetComponent<FinishLevel>();
            Finishing.LoseGame();
        }
    }
}
