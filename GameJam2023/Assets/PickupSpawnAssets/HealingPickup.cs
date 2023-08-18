using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPickup : MonoBehaviour
{
    public float amountToHeal=10f;
    public Target target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealingPotion"))
        {
            DestroyPickup destroyPickup = other.GetComponent<DestroyPickup>();
            destroyPickup.destroyObj();
            target.healup(10);
        }
    }
}