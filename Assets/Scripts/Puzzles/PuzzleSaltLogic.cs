using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSaltLogic : MonoBehaviour
{
   public GameObject dropper;
    public GameObject salPrefab;

    private int currentStep = 0;
    private bool puzzleResuelto = false;

    public void ButtonPressed(string color)
    {
        if (puzzleResuelto) return;

        switch (currentStep)
        {
            case 0:
                if (color == "rojo")
                    currentStep++;
                else
                    ResetPuzzle();
                break;

            case 1:
                if (color == "amarillo")
                    currentStep++;
                else
                    ResetPuzzle();
                break;

            case 2:
                if (color == "verde")
                {
                    currentStep++;
                    DropSalt(); 
                    puzzleResuelto = true;
                }
                else
                {
                    ResetPuzzle();
                }
                break;
        }
    }

    private void DropSalt()
    {
        Instantiate(salPrefab, dropper.transform.position, Quaternion.identity);
        Debug.Log("Puzzle resuelto, aquí tiene su sal");
    }

    private void ResetPuzzle()
    {
        Debug.Log("Secuencia incorrecta. Puzzle reiniciado.");
        currentStep = 0;
    }
}
