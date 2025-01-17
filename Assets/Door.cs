using UnityEngine;

public class Door : MonoBehaviour
{
    // New sprite to be applied to the door
    [SerializeField]
    private Sprite newDoorSprite;

    // Method to change the door's sprite
    public void ChangeSprite()
    {
        if (newDoorSprite != null)
        {
            // Get the SpriteRenderer component and change the sprite
            SpriteRenderer doorSpriteRenderer = GetComponent<SpriteRenderer>();
            if (doorSpriteRenderer != null)
            {
                doorSpriteRenderer.sprite = newDoorSprite;
                Debug.Log("Door sprite changed successfully!");
            }
            else
            {
                Debug.LogError("No SpriteRenderer found on the door!");
            }
        }
        else
        {
            Debug.LogError("No new sprite assigned for the door!");
        }
    }
}
