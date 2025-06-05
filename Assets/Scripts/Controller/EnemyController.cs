using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] int m_health = 1;
    [SerializeField] float speed = 3f; // velocidad de movimiento del enemigo
    [SerializeField] float minDistanceToFollow = 20f; // distancia minima para seguir al jugador	   
    [SerializeField] int damageAmount = 1; // cantidad de danio que hace al jugador

    [SerializeField] protected Transform target; // para obtener posicion del player
    public float cooldownTime = 3f; // Tiempo de cooldown para volver a hacer daño
    NavMeshAgent navMeshAgent;
    Vector3 startPosition;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
        startPosition = transform.position;//transform.LookAt(startPosition);

    }

    void Update()
    {
        if (IsClose())
        {
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            navMeshAgent.ResetPath(); // Detener el movimiento si no esta cerca
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        m_health -= damage;
        if (m_health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        //TODO Agregar animacion de muerte
        navMeshAgent.enabled = false;
        Destroy(gameObject, 1f);
    }

    bool IsClose()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance < minDistanceToFollow;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            Debug.Log("Enemigo ha lastimado al jugador");
            player.TakeDamage(damageAmount);
        }
    }

  
}
