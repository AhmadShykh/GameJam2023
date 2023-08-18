using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeedPotion : MonoBehaviour
{
    public float speedUpTimer = 5f;
    public float speedIncreaseBy = 10f;
    public QueenMovement queenMovement;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("SpeedPotion"))
        {
            DestroyPickup destroyPickup = other.GetComponent<DestroyPickup>();
            destroyPickup.destroyObj();
            queenMovement.IncreaseSpeed(speedIncreaseBy);
            StartCoroutine(DecreaseSpeedAfterDelay());
        }
    }

    private IEnumerator DecreaseSpeedAfterDelay()
    {
        yield return new WaitForSeconds(speedUpTimer);
        queenMovement.IncreaseSpeed(-speedIncreaseBy);
    }
}