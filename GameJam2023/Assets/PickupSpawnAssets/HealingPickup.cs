using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("target"))
        {
            Destroy(gameObject);
        }
    }
}
