using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTextoTrigger : MonoBehaviour
{
    public Transform jugador;
    public GameObject textoUI;
    public float distanciaActivacion = 4f;
    public float anguloVision = 60f;

    void Update()
    {
        if (jugador == null || textoUI == null)
            return;

        Vector3 direccionJugador = jugador.position - transform.position;
        float distancia = direccionJugador.magnitude;

        // ¿Está cerca?
        if (distancia <= distanciaActivacion)
        {
            // ¿Está dentro del campo de visión?
            float angulo = Vector3.Angle(transform.forward, direccionJugador);

            if (angulo <= anguloVision / 2f)
            {
                textoUI.SetActive(true);
                return;
            }
        }

        textoUI.SetActive(false);
    }
}
