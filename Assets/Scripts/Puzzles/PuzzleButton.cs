using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public enum ButtonColor { Red, Yellow, Green }

    public ButtonColor buttonColor;
    public PuzzleButtonManager puzzleManager;

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (puzzleManager != null)
            {
                puzzleManager.PressButton(buttonColor);
                Debug.Log("Botón presionado: " + buttonColor);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
