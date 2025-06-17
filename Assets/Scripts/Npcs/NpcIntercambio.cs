using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcIntercambio : MonoBehaviour
{
    public string message = "Che yo tengo un par de morrones que se que te sirven para el asado y a mi me gusta el pescado. Si me conseguis uno te doy los morrones";
    public GameObject mensajeUI;
    public float campoVision = 60f;
    public Transform cabezaNpc;

    private Transform jugador;
    private bool jugadorCerca = false;
    private bool tienePescado = false;

    void Start()
    {
        if (mensajeUI != null)
        {
            mensajeUI.SetActive(false);
        }
    }

    void Update()
    {
        if (jugadorCerca && EstaMirandoAlJugador())
        {
            mensajeUI.SetActive(true);

            if (tienePescado && Input.GetKeyDown(KeyCode.F))
            {
                DarMorrones();
            }
        }
        else
        {
            mensajeUI.SetActive(false);
        }
    }

    bool EstaMirandoAlJugador()
    {
        if (jugador == null || cabezaNpc == null)
            return false;
        Vector3 direccionAlJugador = (jugador.position - cabezaNpc.position).normalized;
        float angulo = Vector3.Angle(cabezaNpc.forward, direccionAlJugador);

        return angulo < campoVision / 2f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugador = null;
            jugadorCerca = false;
            mensajeUI.SetActive(false);
        }
    }
    void DarMorrones()
    {
        Debug.Log("¡Le diste el pescado y te dio los morrones!");
        tienePescado = false;
        mensajeUI.SetActive(false);
    }
}
