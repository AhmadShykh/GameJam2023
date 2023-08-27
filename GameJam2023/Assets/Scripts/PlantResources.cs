using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantResources : MonoBehaviour
{
    public int Amount ;
	[SerializeField] GameObject[] Resource;
    public void DecreaseAmount(int val)
	{
		Amount -= val;
		Destroy(Resource[Amount]);
		if (Amount <= 0)
		{
			Destroy(gameObject);
		}
			
	}
}
