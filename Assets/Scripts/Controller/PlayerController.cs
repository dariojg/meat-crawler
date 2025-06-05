using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocidad = 8f;
    [SerializeField] float fuerzaSalto = 7.5f;

    [SerializeField] float health = 3f;

    [SerializeField] float gravedadCaida = 5f; // Mas gravedad al caer
    [SerializeField] float gravedadBajada = 3f; // Menos gravedad si se suelta el salto

    [SerializeField] Transform camara;

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
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // subiendo pero solto el salto
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

    void OnTriggerEnter(Collider other) 
    {
          if (other.gameObject.CompareTag("Enemy")) // TODO: Refactor con patron strategy 
          {
              EnemyController enemy = other.GetComponent<EnemyController>();
              Debug.Log("Jugador ha atacado al enemigo.");
              enemy.TakeDamage(1); 
          }
    }

    public void TakeDamage(int damage) // TODO luego cambia a float para tener valores entre 0 y 1
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        // Todo Animacion de muerte

        Debug.Log("Jugador ha muerto...");
        Destroy(gameObject, 2f); 
    }

}