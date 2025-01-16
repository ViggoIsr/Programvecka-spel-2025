using System.Collections;
using TMPro;  // Import TextMeshPro namespace
using UnityEngine;

public class TextPrinter : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshPros;  // Array to store multiple TextMeshProUGUI components
    public float typingSpeed = 0.05f;       // Adjustable speed of typing, seconds between each character
    private string[] fullTexts;             // Array to store full texts for each TextMeshPro
    private string[] currentTexts;          // Array to store texts currently being typed
    private bool[] isTyping;                // Whether each TextMeshPro is typing

    void Start()
    {
        // Ensure the arrays are initialized
        fullTexts = new string[textMeshPros.Length];
        currentTexts = new string[textMeshPros.Length];
        isTyping = new bool[textMeshPros.Length];

        // Loop through each TextMeshProUGUI to initialize
        for (int i = 0; i < textMeshPros.Length; i++)
        {
            if (textMeshPros[i] != null)
            {
                fullTexts[i] = textMeshPros[i].text;  // Store the full text
                textMeshPros[i].text = "";            // Clear the text at the start
                StartTyping(i);                       // Start typing for each TextMeshPro
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component is missing at index " + i);
            }
        }
    }

    // Function to start typing for a specific TextMeshPro
    public void StartTyping(int index)
    {
        if (!isTyping[index])
        {
            StartCoroutine(TypeText(index));
        }
    }

    // Coroutine to type text with delay for a specific TextMeshPro
    private IEnumerator TypeText(int index)
    {
        isTyping[index] = true;
        currentTexts[index] = "";
        foreach (char letter in fullTexts[index])
        {
            currentTexts[index] += letter;                    // Add one character to the current text
            textMeshPros[index].text = currentTexts[index];   // Update the TextMeshPro text
            yield return new WaitForSeconds(typingSpeed);      // Wait for the specified speed
        }
        isTyping[index] = false;
    }
}


