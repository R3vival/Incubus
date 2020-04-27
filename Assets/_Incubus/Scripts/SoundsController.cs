using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    public AudioSource backgroundMusic, FX;

    [Header("FX Clips")]
    public AudioClip openDoorClip;
    public AudioClip puzzleUnlocked;
    public AudioClip wrong;
    [Header("Bacground Music")]
    public AudioClip GameplaySound;
    public void PlayBackgroundMusic()
    {
        backgroundMusic.clip = GameplaySound;
        backgroundMusic.Play();
    }
    
    public void PlayOpenDoorSound()
    {
        FX.clip = openDoorClip;
        FX.Play();
    }
    public void PlayPuzzleUnlockedSound()
    {
        FX.clip = puzzleUnlocked;
        FX.Play();
    }
    public void PlayWrongSound()
    {
        FX.clip = wrong;
        FX.Play();
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }
}
