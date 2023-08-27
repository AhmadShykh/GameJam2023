using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoading : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject LevelScreen;
	private void Start()
	{
        if (GameObject.FindGameObjectWithTag("NextLevel").GetComponent<NextLevelScript>().GoingToNextLevel)
        {
            MainMenu.SetActive(false);
            LevelScreen.SetActive(true);
            GameObject.FindGameObjectWithTag("NextLevel").GetComponent<NextLevelScript>().GoingToNextLevel = false;
        }
    }
}
