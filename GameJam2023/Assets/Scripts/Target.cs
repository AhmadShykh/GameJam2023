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

	void Update()
	{
        CheckFall();	
	}
	public void TakeDamage(float v)
    {
        currentHealth -= v;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(transform.gameObject);
            FinishLevel Finishing = GameObject.FindGameObjectWithTag("Finish").GetComponent<FinishLevel>();
            Finishing.LoseGame();
        }
    }
    void CheckFall()
	{
        if (transform.position.y < -0.74)
            TakeDamage(100);
	}
}
