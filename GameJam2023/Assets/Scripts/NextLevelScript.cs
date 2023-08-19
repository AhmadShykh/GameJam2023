using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelScript : MonoBehaviour
{

	public bool GoingToNextLevel = false;
	private static GameObject PlayerInstance;
	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		if (PlayerInstance == null)
			PlayerInstance = this.gameObject;
		else
			Destroy(PlayerInstance);
	}
}
