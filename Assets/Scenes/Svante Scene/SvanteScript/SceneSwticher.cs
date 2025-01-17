using System.Collections;  // Make sure this is added for IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement;  // Make sure this is added to load scenes

public class SceneSwitcher : MonoBehaviour
{
    public float waitTime = 2f;  // Time to wait before switching the scene

    void Start()
    {
        // Start the coroutine to switch scenes after the wait time
        StartCoroutine(SwitchSceneAfterDelay());
    }

    // Coroutine to wait and switch the scene
    private IEnumerator SwitchSceneAfterDelay()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(waitTime);

        // Load the MainMenu1 scene
        SceneManager.LoadScene("MainMenu (main)");
    }
}
