using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Behövs för att ladda om scenen

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Maximal hälsa
    private int currentHealth; // Nuvarande hälsa

    public TextMeshProUGUI healthText; // Referens till TextMeshPro UI

    void Start()
    {
        // Starta med full hälsa
        currentHealth = maxHealth;

        // Uppdatera hälsan i UI
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Minska hälsan
        UpdateHealthText(); // Uppdatera UI

        // Kontrollera om spelaren dör
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player is dead!");
        // Inaktivera spelaren
        gameObject.SetActive(false);

        // Starta om scenen efter 2 sekunder
        Invoke(nameof(RestartScene), 2f);
    }

    void RestartScene()
    {
        // Ladda om nuvarande scen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kontrollera om spelaren kolliderar med en fiende
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); // Minska hälsan med 1
        }
    }
}

