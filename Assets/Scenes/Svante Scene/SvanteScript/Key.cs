using UnityEngine;

public class Key : MonoBehaviour
{
    // Reference to the specific door this key will unlock
    [SerializeField]
    private GameObject targetDoor;

    // New sprite to be assigned to the door when the key is picked up
    [SerializeField]
    private Sprite newDoorSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with is the player
        if (other.CompareTag("Player"))
        {
            // Attempt to unlock the door if it exists
            if (targetDoor != null)
            {
                // Get the BoxCollider2D of the door and disable it
                BoxCollider2D doorCollider = targetDoor.GetComponent<BoxCollider2D>();
                if (doorCollider != null)
                {
                    doorCollider.enabled = false;
                    Debug.Log("Door unlocked!");

                    // Change the door's sprite
                    ChangeDoorSprite();

                    // Destroy the key after unlocking the door
                    Destroy(gameObject);
                }
                else
                {
                    Debug.LogWarning("The target door does not have a BoxCollider2D!");
                }
            }
            else
            {
                Debug.LogWarning("No door assigned to this key!");
            }
        }
    }

    private void ChangeDoorSprite()
    {
        // Check if the newDoorSprite is assigned
        if (newDoorSprite != null)
        {
            // Try to get the SpriteRenderer from the targetDoor
            SpriteRenderer doorSpriteRenderer = targetDoor.GetComponent<SpriteRenderer>();

            if (doorSpriteRenderer != null)
            {
                // Change the door's sprite to the new one
                doorSpriteRenderer.sprite = newDoorSprite;
                Debug.Log("Door sprite changed successfully!");
            }
            else
            {
                Debug.LogError("The target door does not have a SpriteRenderer component!");
            }
        }
        else
        {
            Debug.LogError("No new sprite assigned for the door! Please assign a sprite in the Inspector.");
        }
    }
}
