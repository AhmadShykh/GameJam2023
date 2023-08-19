using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] Canvas JoyStick;
    [SerializeField] Canvas WinCanvas;
    [SerializeField] Canvas LoseCanvas;
    
    public void WinGame()
	{
        Time.timeScale = 0;
        JoyStick.gameObject.SetActive(false);
        WinCanvas.gameObject.SetActive(true);
    }
    public void LoseGame()
    {
        Time.timeScale = 0;
        JoyStick.gameObject.SetActive(false);
        LoseCanvas.gameObject.SetActive(true);
    }
}
