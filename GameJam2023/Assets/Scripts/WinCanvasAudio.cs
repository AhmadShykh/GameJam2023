using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvasAudio : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioClip hitAudioClip;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (hitAudioClip != null)
        {
            audioSource.PlayOneShot(hitAudioClip);
        }
    }
}
