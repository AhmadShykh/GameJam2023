using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopsSpawning : MonoBehaviour
{
	//Troops Serialized Fields
	[SerializeField] GameObject SoliderAnt;
	[SerializeField] GameObject WorkerAnt;


	private void OnCollisionEnter(Collision collision)
	{
		//Ant Castle Position
		float ZPos = -330, YPos = 30;
		//Ant Random Spawn Area on Z position
		float XPosClamp = 210.0f, XNegClamp = -180.0f;

		if(collision.gameObject.tag == "flower")
		{
			//Random X value where the ant will spawn
			float XPos = Random.Range(XNegClamp, XPosClamp);
			Vector3 AntPos = new Vector3(XPos, YPos, ZPos);

			Instantiate(WorkerAnt, AntPos ,Quaternion.Euler(0,0,0));
		}
	}

}
