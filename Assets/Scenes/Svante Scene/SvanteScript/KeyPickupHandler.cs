using UnityEngine;

public class KeyPickupHandler2D : MonoBehaviour
{
    // Public property to set the door tag
    public string doorTag { get; set; } = "Door";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with is tagged as "Key"
        if (other.CompareTag("Key"))
        {
            // Find the GameObject with the specified door tag
            GameObject door = GameObject.FindGameObjectWithTag(doorTag);

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
                    Debug.LogWarning($"No BoxCollider2D found on the Door with tag '{doorTag}'!");
                }
            }
            else
            {
                Debug.LogWarning($"No GameObject found with the tag '{doorTag}'!");
            }

            // Optionally, destroy the key
            Destroy(other.gameObject);
        }
    }
}


