using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{

    [SerializeField] float m_health = 1f;
    [SerializeField] float speed = 3f; // velocidad de movimiento del enemigo
    [SerializeField] float minDistanceToFollow = 20f; // distancia minima para seguir al jugador	   
    [SerializeField] float damageAmount = 0.2f; // cantidad de danio que hace al jugador

    [SerializeField] protected Transform target; // para obtener posicion del player
    public float cooldownTime = 3f; // Tiempo de cooldown para volver a hacer daño
    NavMeshAgent navMeshAgent;
    Vector3 startPosition;

    float lastAttackTime = -Mathf.Infinity;


    Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
        startPosition = transform.position;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (m_health > 0){
            if (IsClose())
            {
                navMeshAgent.SetDestination(target.position);
                animator.SetBool("isWalking", true);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
                animator.SetBool("isWalking", false);
            }
        }
    }

    public void TakeDamage(float damage)
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
         animator.SetTrigger("die");
         navMeshAgent.ResetPath();
          navMeshAgent.enabled = false;      
        Destroy(gameObject, 5f);

        
    }

    bool IsClose()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance < minDistanceToFollow;
    }

    //void OnTriggerEnter(Collider other)
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Time.time >= lastAttackTime + cooldownTime)
            {
                lastAttackTime = Time.time; // ataca de nuevo

                animator.SetTrigger("attack"); // animacion de ataque

                PlayerController player = other.GetComponent<PlayerController>();
                Debug.Log("Enemigo ha lastimado al jugador");
                player.TakeDamage(damageAmount);
            }
        }
    }
   

}
