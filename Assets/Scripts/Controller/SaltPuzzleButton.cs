using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltPuzzleButton : MonoBehaviour
{
    public string color; 
    public PuzzleSaltLogic puzzleLogic;

    private bool playerInRange;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            puzzleLogic.ButtonPressed(color);
            Debug.Log("Botón presionado: " + color);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
