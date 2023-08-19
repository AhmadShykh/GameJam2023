using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingFunctions : MonoBehaviour
{
    public void ReloadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void GoToMainMenu()
	{
		SceneManager.LoadScene(0);
	}
	public void NextLevel()
	{
		GameObject.FindGameObjectWithTag("NextLevel").GetComponent<NextLevelScript>().GoingToNextLevel = true;
		SceneManager.LoadScene(0);
	}
}
