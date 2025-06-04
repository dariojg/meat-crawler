using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 10f;
    public float fuerzaSalto = 5f;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}
