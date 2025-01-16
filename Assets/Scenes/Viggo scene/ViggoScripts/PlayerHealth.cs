using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; 
    private int currentHealth; 

    public TextMeshProUGUI healthText;

    void Start()
    {
        // Starta med full h�lsa
        currentHealth = maxHealth;

        // Uppdatera h�lsan i UI
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Minska h�lsan
        UpdateHealthText(); // Uppdatera UI

        // Kontrollera om spelaren d�r
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount; // �ka h�lsan
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Begr�nsa h�lsan till maxv�rdet
        }
        UpdateHealthText(); // Uppdatera UI
    }

    void Die()
    {
        Debug.Log("Player is dead!");
        gameObject.SetActive(false);
        Invoke(nameof(RestartScene), 2f); // Starta om scenen efter 2 sekunder
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); 
        }

        if (collision.gameObject.CompareTag("Evil"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPickup"))
        {
            Heal(1); // L�gg till 1 h�lsa
            Destroy(collision.gameObject); // Ta bort h�lsopickupen fr�n scenen
        }
    }
    
}

