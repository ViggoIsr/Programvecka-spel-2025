using UnityEngine;




public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the collider belongs to the player
        {
            Debug.Log("Key picked up!");
            PlayerInventory.HasKey = true; // Player now has the key
            Destroy(gameObject); // Remove the key
        }
    }
}
