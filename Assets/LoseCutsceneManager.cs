using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCutsceneManager : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("PlayerDied", 0) == 1)
        {
            PlayerPrefs.SetInt("PlayerDied", 0); // Återställ flaggan
            PlayerPrefs.Save();
            Invoke(nameof(LoadGameScene), 1f); // Vänta 1 sekunder innan respawn
        }
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("Backup shirr");
    }
}
