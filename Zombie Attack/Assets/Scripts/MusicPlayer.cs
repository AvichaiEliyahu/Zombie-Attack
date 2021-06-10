using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum music_options {PLAY, PAUSE,STOP }

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip insideMusic;
    [SerializeField] AudioClip outsideMusic;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = insideMusic;
        audioSource.Play();
    }

    public void StartOutsideMusic()
    {
        audioSource.clip = outsideMusic;
        audioSource.volume = 0.4f;
        audioSource.Play();
    }

    public void MusicControls(music_options option)
    {
        switch (option)
        {
            case music_options.PLAY:
                audioSource.Play();
                break;
            case music_options.PAUSE:
                audioSource.Pause();
                break;
            case music_options.STOP:
                audioSource.Stop();
                break;
            default:
                return;

        }
    }

    

    

}
