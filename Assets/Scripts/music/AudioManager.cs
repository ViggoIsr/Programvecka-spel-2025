using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource musicSource;
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void PlayMusic(AudioClip newClip)
    {//doesnt restart track
        if (musicSource == newClip && musicSource.isPlaying)
            return;

        musicSource.clip = newClip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }


}
