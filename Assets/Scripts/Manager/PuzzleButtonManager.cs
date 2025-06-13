using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtonManager : MonoBehaviour
{
    public Transform saltSpawnPoint;
    public GameObject saltPrefab;

    private PuzzleButton.ButtonColor[] correctOrder = {
        PuzzleButton.ButtonColor.Red,
        PuzzleButton.ButtonColor.Yellow,
        PuzzleButton.ButtonColor.Green
    };

    private int currentIndex = 0;
    private bool puzzleCompleted = false;

    public void PressButton(PuzzleButton.ButtonColor pressedColor)
    {
        if (puzzleCompleted)
        {
            return;
        }

        if (pressedColor == correctOrder[currentIndex])
        {
            currentIndex++;
            Debug.Log("Correcto: " + pressedColor);
        }

        if (currentIndex == correctOrder.Length)
        {
            Debug.Log("¡Puzzle Resuelto");
            puzzleCompleted = true;
            DropSalt();
        }

        else
        {
            Debug.Log("Orden incorrecto");
            currentIndex = 0;
        }
    }

    public void DropSalt()
    {
        Instantiate(saltPrefab, saltSpawnPoint.position, Quaternion.identity);
    }
}
