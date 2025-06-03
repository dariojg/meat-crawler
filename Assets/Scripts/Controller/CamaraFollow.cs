using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform objetivo; // Jugador
    public Vector3 offset = new Vector3(0f, 5f, -7f);
    public float suavizado = 0.125f;

    private Vector3 velocidad = Vector3.zero;

    void LateUpdate()
    {
        // Calcula la posición deseada sin cambiar rotación
        Vector3 posicionDeseada = objetivo.position + offset;

        // Mueve suavemente hacia la posición
        transform.position = Vector3.SmoothDamp(transform.position, posicionDeseada, ref velocidad, suavizado);
    }
}