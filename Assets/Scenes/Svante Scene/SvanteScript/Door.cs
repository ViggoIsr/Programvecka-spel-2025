using UnityEngine;

public class Door : MonoBehaviour
{
    private Collider2D doorCollider;

    private void Start()
    {
        // Cache the door's Collider2D component
        doorCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerInventory.HasKey)
            {
                Debug.Log("Door unlocked! You can pass through.");
                doorCollider.enabled = false; // Disable the door's collider
            }
            else
            {
                Debug.Log("The door is locked. Find the key first!");
            }
        }
    }
}
