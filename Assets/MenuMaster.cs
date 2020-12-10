using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class MenuMaster : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas searchGameCanvas;
    public Canvas optionsCanvas;
    public AudioSource audioSource;
    public AudioMixerGroup mixerGroupSFX;
    public void Start()
    {
        enableMainMenu();
    }

    public void enableMainMenu()
    {
        mainMenuCanvas.enabled = true;
        searchGameCanvas.enabled = true;
        optionsCanvas.enabled = false;
    }
    public void PlaySFX(AudioClip SFX)
    {
        audioSource.outputAudioMixerGroup = mixerGroupSFX;
        audioSource.PlayOneShot(SFX);
    }
    
    public void enableOptionsMenu()
    {
        mainMenuCanvas.enabled = false;
        searchGameCanvas.enabled = false;
        optionsCanvas.enabled = true;
    }
}