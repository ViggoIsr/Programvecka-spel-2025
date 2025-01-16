using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class SceneTrigger : MonoBehaviour
{
    // The name of the scene to load
    [SerializeField] private string sceneToLoad;

    // This method is called when another object enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
