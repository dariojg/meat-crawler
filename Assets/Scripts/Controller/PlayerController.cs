using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 5f;
    public LayerMask capaSuelo;

    private Rigidbody rb;
    private bool enSuelo;
    private Camera camara;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camara = Camera.main;
    }

    void Update()
    {
        // Salto
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }

        // Rotar hacia el cursor
        RotarHaciaCursor();
    }

    void FixedUpdate()
    {
        // Movimiento
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(h, 0f, v).normalized * velocidad;
        Vector3 velocidadActual = rb.velocity;
        rb.velocity = new Vector3(movimiento.x, velocidadActual.y, movimiento.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    void RotarHaciaCursor()
    {
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, capaSuelo))
        {
            Vector3 puntoObjetivo = hit.point;
            Vector3 direccion = (puntoObjetivo - transform.position);
            direccion.y = 0f; // No rotar en vertical

            if (direccion.magnitude > 0.1f)
            {
                Quaternion rotacion = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, 10f * Time.deltaTime);
            }
        }
    }
}