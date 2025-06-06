using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocidad = 8f;
    [SerializeField] float jumpingForce = 60f;
    [SerializeField] int health = 3;
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
            rb.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
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

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.TryGetComponent<EnemyController>(out var enemy))
            {
                bool isUpCollision = !enSuelo && (transform.position.y > enemy.transform.position.y);
                if (isUpCollision)
                {
                    Debug.Log("Jugador ha golpeado al enemigo.");
                    enemy.TakeDamage(1);
                    rb.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse); // Rebote al golpear
                }
            }
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
        SceneManager.LoadScene("GameOverScreen");
    }

}