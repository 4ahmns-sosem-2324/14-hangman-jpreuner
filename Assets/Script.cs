using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Schritt 1: Definiere die benötigten UI-Elemente
// Benötigte UI-Elemente sind ein Textfeld, um das zu erratende Wort anzuzeigen,
// ein Textfeld, um die bereits geratenen Buchstaben anzuzeigen, und ein Button,
// um das Spiel neu zu starten.

// Schritt 2: Definiere eine Liste von Wörtern
// Erstelle eine Liste von Wörtern, aus denen das Spiel zufällig auswählen kann.

// Schritt 3: Verwalte das zu erratende Wort und die geratenen Buchstaben
// Erstelle eine Variable, um das zu erratende Wort zu speichern.
// Erstelle eine Liste, um die geratenen Buchstaben zu speichern.

// Schritt 4: Starte ein neues Spiel
// Beim Start des Spiels wähle zufällig ein Wort aus der Liste der Wörter aus,
// lösche die Liste der geratenen Buchstaben und aktualisiere die Anzeige.

// Schritt 5: Aktualisiere die Anzeige für das zu erratende Wort
// Erstelle eine Methode, um die Anzeige des zu erratenden Wortes zu aktualisieren.
// Durchlaufe das zu erratende Wort und zeige für jeden Buchstaben entweder den
// Buchstaben selbst oder einen Platzhalter an, falls der Buchstabe noch nicht
// geraten wurde.

// Schritt 6: Rate einen Buchstaben
// Erstelle eine Methode, um einen Buchstaben zu raten.
// Füge den geratenen Buchstaben zur Liste hinzu und aktualisiere die Anzeige.

// Schritt 7: Handle den Neustart des Spiels
// Erstelle eine Methode, um das Spiel neu zu starten.
// Wähle ein neues Wort aus, lösche die Liste der geratenen Buchstaben und aktualisiere die Anzeige.

// Schritt 8: Integriere die UI-Elemente
// Weise den UI-Elementen die entsprechenden Variablen zu und verknüpfe
// sie mit den entsprechenden Methoden (z.B. beim Klicken des Neustart-Buttons).

// Schritt 9: Teste und verfeinere dein Spiel
// Überprüfe das Spiel gründlich, um sicherzustellen, dass alle Funktionen ordnungsgemäß funktionieren.
// Füge zusätzliche Funktionen hinzu, wie z.B. ein Punktesystem oder verschiedene Schwierigkeitsstufen.





public class Script : MonoBehaviour
{
    // Methode zum Auswählen eines zufälligen Wortes aus einem String-Array
    string SelectRandomWord(string[] wordArray)
    {
        // Überprüfe, ob das Array nicht leer ist
        if (wordArray != null && wordArray.Length > 0)
        {
            // Wähle ein zufälliges Index aus dem Array
            int randomIndex = Random.Range(0, wordArray.Length);

            // Gib das Wort an diesem Index zurück
            return wordArray[randomIndex];
        }
        else
        {
            // Gib eine Fehlermeldung aus, falls das Array leer ist
            Debug.LogError("Word array is empty or null.");
            return null;
        }
    }

    // Beispielaufruf der Methode
    void Start()
    {
        // Ein Array von 5 Wörtern
        string[] words5 = { "Computer", "Programmierung", "Hangman", "Unity", "Entwicklung" };
        // Ein Array von 10 Wörtern
        string[] words10 = { "Apple", "Banana", "Carrot", "Dog", "Elephant", "Fish", "Giraffe", "Horse", "Ice cream", "Jellyfish" };
        // Ein Array von 100 Wörtern
        string[] words100 = new string[100];
        for (int i = 0; i < 100; i++)
        {
            words100[i] = "Word" + i;
        }

        // Wähle ein zufälliges Wort aus jedem Array aus
        string selectedWord5 = SelectRandomWord(words5);
        string selectedWord10 = SelectRandomWord(words10);
        string selectedWord100 = SelectRandomWord(words100);

        // Gib die ausgewählten Wörter aus
        Debug.Log("Selected Word from 5 options: " + selectedWord5);
        Debug.Log("Selected Word from 10 options: " + selectedWord10);
        Debug.Log("Selected Word from 100 options: " + selectedWord100);
    }
}

