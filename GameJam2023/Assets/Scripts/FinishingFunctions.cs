using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingFunctions : MonoBehaviour
{
    public void ReloadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
	}
	public void GoToMainMenu()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}
	public void NextLevel()
	{
		Time.timeScale = 1;
		GameObject.FindGameObjectWithTag("NextLevel").GetComponent<NextLevelScript>().GoingToNextLevel = true;
		SceneManager.LoadScene(0);
	}
}
