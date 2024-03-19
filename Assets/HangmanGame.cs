using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class HangmanGame : MonoBehaviour
{
    public Text wordDisplayText;
    public Text attemptsText;
    public Text incorrectGuessesText; // Text zur Anzeige der falsch geratenen Buchstaben
    public InputField inputField;
    public GameObject gameOverPanel;

    private string[] words = { "apple", "banana", "orange", "strawberry", "kiwi", "pineapple" };
    private string wordToGuess;
    private List<char> guessedLetters = new List<char>();
    private List<char> incorrectGuesses = new List<char>(); // Liste für falsche geratene Buchstaben
    private int attempts;
    private Image[] hangmanImages; // Array von Galgenmännchen-Bildern für verschiedene Versuchs-Stufen

    void Start()
    {
        // Holen Sie sich die Image-Komponenten vom GameObject
        hangmanImages = GetComponentsInChildren<Image>();

        // Starte das Spiel und setze die Galgenmännchen-Bilder entsprechend der Anzahl der Versuche
        StartGame();
    }

    void StartGame()
    {
        // Zufälliges Wort auswählen
        wordToGuess = words[Random.Range(0, words.Length)];

        // Zurücksetzen der geratenen Buchstaben und Versuche
        guessedLetters.Clear();
        incorrectGuesses.Clear();
        attempts = hangmanImages.Length - 1; // Setzen der Versuche auf die Anzahl der Galgenmännchen-Bilder

        // Bildanzeigen aktualisieren
        UpdateUI();

        // Deaktiviere alle Galgenmännchen-Bilder außer dem ersten
        for (int i = 1; i < hangmanImages.Length; i++)
        {
            hangmanImages[i].gameObject.SetActive(false);
        }
    }

    void UpdateUI()
    {
        // Wortanzeige aktualisieren
        string display = "";
        foreach (char letter in wordToGuess)
        {
            if (guessedLetters.Contains(letter))
            {
                display += letter + " "; // Leerzeichen hinzufügen
            }
            else
            {
                display += "_ "; // Leerzeichen hinzufügen
            }
        }
        wordDisplayText.text = display;

        // Anzahl der Versuche anzeigen
        attemptsText.text = "Versuche übrig: " + attempts.ToString();

        // Falsch geratene Buchstaben anzeigen
        string incorrectGuessesDisplay = "Falsch geraten: ";
        foreach (char letter in incorrectGuesses)
        {
            incorrectGuessesDisplay += letter + " ";
        }
        incorrectGuessesText.text = incorrectGuessesDisplay;
    }

    public void GuessLetter()
    {
        // Buchstaben-Eingabe des Spielers abrufen
        char guess = inputField.text.ToLower()[0];
        inputField.text = "";

        // Überprüfen, ob der Buchstabe bereits geraten wurde
        if (!guessedLetters.Contains(guess))
        {
            guessedLetters.Add(guess);

            // Überprüfen, ob der Buchstabe im Wort enthalten ist
            if (!wordToGuess.Contains(guess.ToString()))
            {
                attempts--; // Reduziere die Anzahl der Versuche
                incorrectGuesses.Add(guess); // Hinzufügen des falschen Buchstabens
                UpdateHangmanImage(); // Aktualisiere das Bild des Galgenmännchens
            }

            // Spielzustand überprüfen
            UpdateUI();
            if (attempts == 0)
            {
                GameOver(false);
            }
            else if (wordToGuess.All(letter => guessedLetters.Contains(letter)))
            {
                GameOver(true);
            }
        }
    }

    void UpdateHangmanImage()
    {
        // Aktualisiere das Bild des Galgenmännchens entsprechend der Anzahl der verbleibenden Versuche
        int activeIndex = hangmanImages.Length - attempts - 1; // Index des aktiven Galgenmännchen-Bildes
        for (int i = 0; i < hangmanImages.Length; i++)
        {
            hangmanImages[i].gameObject.SetActive(i == activeIndex); // Aktiviere das entsprechende Bild
        }
    }

    void GameOver(bool win)
    {
        // Zeige das Game Over Panel an
        gameOverPanel.SetActive(true);
        Text gameOverText = gameOverPanel.GetComponentInChildren<Text>();
        if (win)
        {
            gameOverText.text = "Glückwunsch! Das Wort war: " + wordToGuess;
        }
        else
        {
            gameOverText.text = "Game Over! Das Wort war: " + wordToGuess;
        }
    }

    public void RestartGame()
    {
        // Starte das Spiel neu und deaktiviere das Game Over Panel
        StartGame();
        gameOverPanel.SetActive(false);
    }
}
