using UnityEngine;

public class Key : MonoBehaviour
{
    // Reference to the specific door this key will unlock
    [SerializeField] private GameObject targetDoor;

    // References to door sprites that can be set in the inspector
    [SerializeField] private Sprite lockedDoorSprite;
    [SerializeField] private Sprite unlockedDoorSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with is the player
        if (other.CompareTag("Player"))
        {
            // Attempt to unlock the door if it exists
            if (targetDoor != null)
            {
                // Get the required components
                BoxCollider2D doorCollider = targetDoor.GetComponent<BoxCollider2D>();
                SpriteRenderer doorSprite = targetDoor.GetComponent<SpriteRenderer>();

                if (doorCollider != null && doorSprite != null)
                {
                    // Disable the collider
                    doorCollider.enabled = false;

                    // Change the door sprite to unlocked
                    if (unlockedDoorSprite != null)
                    {
                        doorSprite.sprite = unlockedDoorSprite;
                    }
                    else
                    {
                        Debug.LogWarning("Unlocked door sprite not assigned!");
                    }

                    Debug.Log("Door unlocked!");

                    // Destroy the key after unlocking the door
                    Destroy(gameObject);
                }
                else
                {
                    if (doorCollider == null)
                    {
                        Debug.LogWarning("The target door does not have a BoxCollider2D!");
                    }
                    if (doorSprite == null)
                    {
                        Debug.LogWarning("The target door does not have a SpriteRenderer!");
                    }
                }
            }
            else
            {
                Debug.LogWarning("No door assigned to this key!");
            }
        }
    }
}