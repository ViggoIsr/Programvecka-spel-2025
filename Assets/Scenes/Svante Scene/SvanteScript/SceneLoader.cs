using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    // Method to load a scene by name
    /*public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }*/

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HandleMusicScene(scene);
        Debug.Log("scene " + scene.name);
    }

    private void HandleMusicScene(Scene scene)
    {
        if(scene.name == "MainMenu (main)")
        {
            Debug.Log("main menu music is playing");
            audioManager.PlayMusic(audioManager.mainMenuMusic);
            
        }
        else
        {
            Debug.Log("game music is playing");
            audioManager.PlayMusic(audioManager.gameMusic);
            
        }
    }

    // Method to quit the application
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
