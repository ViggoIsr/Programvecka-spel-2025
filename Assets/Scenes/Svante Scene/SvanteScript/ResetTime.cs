using UnityEngine;

public class ResetTime : MonoBehaviour
{
    // This method resets the time scale to 1
    public void ResetTimeScale()
    {
        Time.timeScale = 1f;
        Debug.Log("Time scale reset to 1");
    }
}
