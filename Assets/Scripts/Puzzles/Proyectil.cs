using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoVida = 2f;
    public float damage = 1f;

    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerSalud saludJugador = collision.GetComponent<PlayerSalud>();

            if (saludJugador != null)
            {
                saludJugador.vida -= damage;

                if (saludJugador.vida <= 0)
                {
                    Destroy(collision.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}
