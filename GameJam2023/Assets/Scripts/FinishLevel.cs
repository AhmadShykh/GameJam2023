using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] Canvas JoyStick;
    [SerializeField] Canvas WinCanvas;
    [SerializeField] Canvas LoseCanvas;
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip loseClip;
    [SerializeField] AudioSource EventAudioSource;
    public void WinGame()
    {
        EventAudioSource.PlayOneShot(winClip);
        Time.timeScale = 0;
        JoyStick.gameObject.SetActive(false);
        WinCanvas.gameObject.SetActive(true);
    }

    public void LoseGame()
    {
        EventAudioSource.PlayOneShot(loseClip);
        Time.timeScale = 0;
        JoyStick.gameObject.SetActive(false);
        LoseCanvas.gameObject.SetActive(true);
    }
}
