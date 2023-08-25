using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] Canvas JoyStick;
    [SerializeField] Canvas WinCanvas;
    [SerializeField] Canvas LoseCanvas;
    [SerializeField] AudioSource winClip;
    [SerializeField] AudioSource loseClip;

    public void WinGame()
    {
        if (winClip != null)
        {
            winClip.Play();
        }

        Time.timeScale = 0;
        JoyStick.gameObject.SetActive(false);
        WinCanvas.gameObject.SetActive(true);
    }

    public void LoseGame()
    {
        if (loseClip != null)
        {
            loseClip.Play();
        }

        Time.timeScale = 0;
        JoyStick.gameObject.SetActive(false);
        LoseCanvas.gameObject.SetActive(true);
    }
}
