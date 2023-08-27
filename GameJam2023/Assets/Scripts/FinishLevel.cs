using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [Header("Win Lose Settings")]
    [SerializeField] Canvas JoyStick;
    [SerializeField] Canvas WinCanvas;
    [SerializeField] Canvas LoseCanvas;
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip loseClip;
    [SerializeField] AudioSource EventAudioSource;
    [SerializeField] int WorldNum;
    public void WinGame()
    {
        EventAudioSource.PlayOneShot(winClip);
        Time.timeScale = 0;
        JoyStick.gameObject.SetActive(false);
        WinCanvas.gameObject.SetActive(true);
        PlayerPrefs.SetInt("World" + WorldNum.ToString() + "Levels", PlayerPrefs.GetInt("World" + WorldNum.ToString() + "Levels") + 1);
    }

    public void LoseGame()
    {
        EventAudioSource.PlayOneShot(loseClip);
        Time.timeScale = 0;
        JoyStick.gameObject.SetActive(false);
        LoseCanvas.gameObject.SetActive(true);
    }
}
