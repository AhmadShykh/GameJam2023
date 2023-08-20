using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDamaging : MonoBehaviour
{
    [SerializeField] float TotalHealth = 10f;
    [SerializeField] float PushForce = 4f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("army ant" ) || other.gameObject.CompareTag("Spider"))
        {
            other.gameObject.transform.Translate(Vector3.down * PushForce);
            AntAttacking AntComponent = other.gameObject.GetComponent<AntAttacking>();
            if (AntComponent.CanAttack) {
                TotalHealth -= AntComponent.Damage;
                AntComponent.CanAttack = false;
            }
            if(TotalHealth <= 0)
			{
                Destroy(gameObject);
			}
        }
    }
}
