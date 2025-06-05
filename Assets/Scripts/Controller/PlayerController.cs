using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 11f;
    public float fuerzaSalto = 7.5f;

    public float gravedadCaida = 5f; // Más gravedad al caer
    public float gravedadBajada = 3f; // Menos gravedad si se suelta el salto

    public Transform camara;

    private Rigidbody rb;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical).normalized;

        if (movimiento.magnitude >= 0.1f)
        {
            Vector3 direccionCamara = camara.TransformDirection(movimiento);
            direccionCamara.y = 0f;
            direccionCamara.Normalize();

            Vector3 nuevaPosicion = rb.position + direccionCamara * velocidad * Time.deltaTime;

            rb.MovePosition(nuevaPosicion);

            Quaternion rotacionDeseada = Quaternion.LookRotation(direccionCamara);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, Time.deltaTime * 10f);
        }

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }
    }

    void FixedUpdate()
    {
        // Gravedad mejorada
        if (rb.velocity.y < 0) // cayendo
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (gravedadCaida - 1), ForceMode.Acceleration);
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // subiendo pero soltó el salto
        {
            rb.AddForce(Vector3.up * Physics.gravity.y * (gravedadBajada - 1), ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}