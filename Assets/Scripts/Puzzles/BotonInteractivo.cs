using UnityEngine;

public class BotonInteractivo : Puzzle
{
    private bool activado = false;
    private bool jugadorEnRango = false;

    void Update()
    {
        if (jugadorEnRango && !activado && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Jugador en rango y activado");
            activado = true;
            NotifyPuzzelResolved();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Jugador ha entrado en el rango del botón.");
        if (other.CompareTag("Player"))
        {
            jugadorEnRango = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnRango = false;
        }
    }
}
