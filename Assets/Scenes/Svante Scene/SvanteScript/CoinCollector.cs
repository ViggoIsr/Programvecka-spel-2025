using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Reference to the TMP text
    private int coinCount = 0;       // Counter for collected coins

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        // Check if the collided object has the "Coin" tag
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); // Destroy the coin
            coinCount++;                  // Increment the coin count
            UpdateCoinText();             // Update the UI text
        }
    }

    // Method to update the TMP text
    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount;
    }
}
