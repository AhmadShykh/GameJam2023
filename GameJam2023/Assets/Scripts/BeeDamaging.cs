using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDamaging : MonoBehaviour
{
    [SerializeField] float TotalHealth = 10f;
    [SerializeField] float PushForce = 4f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        if (other.gameObject.tag == "army ant")
        {
            other.gameObject.transform.Translate(Vector3.down * PushForce);
            TotalHealth -= other.gameObject.GetComponent<AntAttacking>().Damage;
            if(TotalHealth <= 0)
			{
                Destroy(gameObject);
			}
        }
    }
}
