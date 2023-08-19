using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenDamaging : MonoBehaviour
{
    [SerializeField] float PushForce = 5f;
	[Header("Ant Settings")]
	[SerializeField] GameObject WorkerAnt;
	[SerializeField] GameObject ArmyAnt;
	[SerializeField] float YPos = 1.7f;
	[SerializeField] float ZPos = -19.5f;
	[SerializeField] float XNegPos = -6.5f;
	[SerializeField] float XPositivePos = 12.5f;
	

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "bee")
		{
			other.gameObject.transform.Translate(new Vector3(0,-1,0) * PushForce);
			gameObject.GetComponent<Target>().TakeDamage(other.gameObject.GetComponent<BeesAttacking>().Damage);
		}
		else if (other.gameObject.tag == "mushroom")
		{
			SpawnAnt(WorkerAnt, other.gameObject);
		}
		else if (other.gameObject.tag == "flower")
		{
			SpawnAnt(ArmyAnt, other.gameObject);
		}
	}
	void SpawnAnt(GameObject obj,GameObject otherObj)
	{
		float XPos = Random.Range(XNegPos, XPositivePos);
		Instantiate(obj, new Vector3(XPos, YPos, ZPos), Quaternion.Euler(-90, 180, 0));
		Destroy(otherObj);
	}
}
