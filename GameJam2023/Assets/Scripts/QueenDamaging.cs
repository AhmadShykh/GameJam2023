using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenDamaging : MonoBehaviour
{
    [SerializeField] float PushForce = 5f;
	[Header("Ant Settings")]
	[SerializeField] GameObject WorkerAnt;
	[SerializeField] GameObject ArmyAnt;
	[SerializeField] float YPos = 1.3f;
	[SerializeField] float ZPos = -19.5f;
	[SerializeField] float XNegPos = -6.5f;
	[SerializeField] float XPositivePos = 12.5f;
	
	

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "bee")
		{
			other.gameObject.transform.Translate(Vector3.down * PushForce);
			gameObject.GetComponent<Target>().TakeDamage(other.gameObject.GetComponent<BeesAttacking>().Damage);
		}
		else if (other.gameObject.tag == "mushroom")
		{
			float XPos = Random.Range(XNegPos, XPositivePos);
			Instantiate(WorkerAnt, new Vector3(XPos,YPos,ZPos),Quaternion.Euler(-90,180,0));
		}
		else if (other.gameObject.tag == "flower")
		{
			float XPos = Random.Range(XNegPos, XPositivePos);
			Instantiate(ArmyAnt, new Vector3(XPos, YPos, ZPos), Quaternion.Euler(-90, 180, 0));
		}
	}
	
}
