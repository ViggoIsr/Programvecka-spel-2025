using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private string targetScene;

    // Method called when the button is clicked
    public void LoadTargetScene()
    {
        SoundManager.Instance.PlaySound3D("MenuClick", transform.position);
        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogWarning("Target scene name is not set on " + gameObject.name);
        }
    }
}
