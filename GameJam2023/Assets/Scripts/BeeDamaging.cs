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
            Vector3 PushPos;
            if (other.gameObject.tag == "army ant") PushPos = Vector3.down;
            else PushPos = Vector3.forward;
            other.gameObject.transform.Translate(PushPos * PushForce);
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
