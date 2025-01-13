using UnityEngine;

public class KeyPickupHandler2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with is tagged as "Key"
        if (other.CompareTag("Key"))
        {
            // Find the GameObject tagged as "Door"
            GameObject door = GameObject.FindGameObjectWithTag("Door");

            if (door != null)
            {
                // Disable the BoxCollider2D of the Door
                BoxCollider2D doorCollider = door.GetComponent<BoxCollider2D>();
                if (doorCollider != null)
                {
                    doorCollider.enabled = false;
                    Debug.Log("Door unlocked!");
                }
                else
                {
                    Debug.LogWarning("No BoxCollider2D found on the Door!");
                }
            }
            else
            {
                Debug.LogWarning("No GameObject found with the tag 'Door'!");
            }

            // Optionally, destroy the key
            Destroy(other.gameObject);
        }
    }
}
