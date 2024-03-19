using UnityEngine;
using UnityEngine.UI;

public class HangmanInput : MonoBehaviour
{
    public HangmanGame gameManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameManager.GuessLetter();
        }
    }
}
