using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonInteractivo : MonoBehaviour
{
    private static int botonesActivados = 0;
    private static int totalBotones = 2;
    private bool activado = false;
    private bool jugadorEnRango = false;

    void Update()
    {
        if (jugadorEnRango && !activado && Input.GetKeyDown(KeyCode.F))
        {
            activado = true;
            botonesActivados++;

            if (botonesActivados < totalBotones)
            {
                Debug.Log("Activaste 1 boton. Falta otro");
            }
            else
            {
                Debug.Log("Activaste todos los botones");
            }
            if (botonesActivados == totalBotones)
            {
                GameObject porton = GameObject.FindGameObjectWithTag("Porton");
                if (porton != null)
                {
                    Destroy(porton);
                    Debug.Log("Puerta abierta. A por el ultimo ingrediente");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
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
