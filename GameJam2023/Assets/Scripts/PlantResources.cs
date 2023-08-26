using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantResources : MonoBehaviour
{
    public int Amount ;
    public void DecreaseAmount(int val)
	{
		Amount -= val;
		if (Amount <= 0)
			Destroy(gameObject);
	}
}
