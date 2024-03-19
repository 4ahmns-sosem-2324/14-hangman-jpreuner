using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WortListen : MonoBehaviour
{
    // Ein Array von 5 Wörtern
    string[] words5 = { "Computer", "Programmierung", "Hangman", "Unity", "Entwicklung" };
    // Ein Array von 10 Wörtern
    string[] words10 = { "Apple", "Banana", "Carrot", "Dog", "Elephant", "Fish", "Giraffe", "Horse", "Ice cream", "Jellyfish" };
    // Ein Array von 100 Wörtern
    string[] words100 = new string[100];

    private void Start()
    {
        GenerateWordList(6);
    }

    string[] GenerateWordList(int wordLenght)

    {
        string[] tmpArray = new string[wordLenght];
        for (int i = 0; i < wordLenght; i++)
        {
           tmpArray[i] = "Word" + i;
        }
        return tmpArray;
    }
}
