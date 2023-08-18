using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenDamaging : MonoBehaviour
{
    [SerializeField] float PushForce = 5f;

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
	    if(other.gameObject.tag == "bee")
		{
            other.gameObject.transform.Translate(Vector3.down * PushForce);
            gameObject.GetComponent<Target>().TakeDamage(other.gameObject.GetComponent<BeesAttacking>().Damage);
        }
	}
	
}
