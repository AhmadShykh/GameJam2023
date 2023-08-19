using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaintain : MonoBehaviour
{
	public static GameObject PlayerInstance;
	[SerializeField] GameObject NextLevelObj;
	private void Awake()
	{

		if (PlayerInstance == null)
		{
			Instantiate(NextLevelObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("NextLevel"));
			PlayerInstance = GameObject.FindGameObjectWithTag("NextLevel");
			Debug.Log("bye");
		}

	}
}
