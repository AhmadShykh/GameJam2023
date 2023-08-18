using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoringSugar : MonoBehaviour
{
    public float MaxSugar = 100;
    public float currentSugar;
    public HealthBar SugarBar;
    void Start()
    {
        currentSugar = 0;
        SugarBar.SetMaxHealth(MaxSugar );
        SugarBar.SetHealth(currentSugar);
    }

    public void GiveSugar(float v)
    {
        currentSugar += v;
        SugarBar.SetHealth(currentSugar );
        if (currentSugar >= MaxSugar)
        {
            Debug.Log("Win");
        }
    }

}
