using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUnlocked : MonoBehaviour
{
	[Header("Level Button Settings")]
	[SerializeField] Button[] LevelButtons;
	[SerializeField] int WorldNum;

	private void Start()
	{

		if (!PlayerPrefs.HasKey("World" + WorldNum.ToString() + "Levels"))
			PlayerPrefs.SetInt("World" + WorldNum.ToString() + "Levels", 1);
		UnlockLevels();
				
	}
	void UnlockLevels()
	{
		Debug.Log(PlayerPrefs.GetInt("World" + WorldNum.ToString() + "Levels"));
		for(int BtnNum = 1; BtnNum <= PlayerPrefs.GetInt("World" + WorldNum.ToString() + "Levels"); BtnNum++)
		{
			LevelButtons[BtnNum - 1].interactable = true;
		}
	}
}
