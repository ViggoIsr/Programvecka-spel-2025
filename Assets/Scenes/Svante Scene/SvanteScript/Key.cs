using UnityEngine;

public class Key : MonoBehaviour
{
    // Reference to the specific door this key will unlock
    [SerializeField]
    private GameObject targetDoor;

    // SpriteRenderer of the target door
    [SerializeField]
    private SpriteRenderer doorSpriteRenderer;

    // New sprite to be assigned to the door when the key is picked up
    [SerializeField]
    private Sprite newDoorSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with is the player
        if (other.CompareTag("Player"))
        {
            UnlockDoor();

            // Destroy the key after unlocking the door
            Destroy(gameObject);
        }
    }

    private void UnlockDoor()
    {
        if (targetDoor == null)
        {
            Debug.LogWarning("No door assigned to this key!");
            return;
        }

        // Disable the door's collider
        BoxCollider2D doorCollider = targetDoor.GetComponent<BoxCollider2D>();
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
            Debug.Log("Door unlocked!");
        }
        else
        {
            Debug.LogWarning("The target door does not have a BoxCollider2D!");
        }

        // Change the door's sprite
        if (doorSpriteRenderer != null && newDoorSprite != null)
        {
            doorSpriteRenderer.sprite = newDoorSprite;
            Debug.Log("Door sprite changed successfully.");
        }
        else if (doorSpriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer for the door is not assigned in the Inspector!");
        }
        else
        {
            Debug.LogError("New sprite for the door is not assigned in the Inspector!");
        }
    }
}
