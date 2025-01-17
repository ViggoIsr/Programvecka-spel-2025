using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        MusicManager.Instance.PlayMusic("MainMenuMusic");
    }

    public void Play()
    {
        MusicManager.Instance.PlayMusic("MainMenuMusic");
    }
}
