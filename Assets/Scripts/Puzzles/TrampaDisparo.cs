using UnityEngine;

public class TrampaDisparo : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float velocidad = 10f;
    public float intervaloDisparo = 3f;

    public void Start()
    {
        InvokeRepeating(nameof(Disparar), 0f, intervaloDisparo);
    }

    public void Disparar()
    {
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = puntoDisparo.forward * velocidad;
        }
    }

}
