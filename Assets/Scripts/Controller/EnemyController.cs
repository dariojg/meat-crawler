using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float m_health = 20f;

    [SerializeField] protected Transform target; // para obtener posicion del player
   
    [SerializeField] int damageAmount = 1; // cantidad de danio que hace al jugador
    public float cooldownTime = 3f; // Tiempo de cooldown para volver a hacer daño
    private float lastAttackTime;
    protected NavMeshAgent navMeshAgent;

    protected void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
    }

    protected void Update()
    {
        if(m_health > 0){
            navMeshAgent.SetDestination(target.position);
        }else{
            Destroy(gameObject, 3f);
        }
    }

    public void TakeDamage(float damage)
    {
        m_health -= damage;
        if(m_health <= 0){
            Death(); 
        }
    }

    void Death()
    {
        //TODO Agregar animacion de muerte

        navMeshAgent.enabled = false;
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            //TODO logica de danio al jugador
            /*if(Time.time >= lastAttackTime + cooldownTime && !player.IsDeath && this.m_health > 0)
            {
                lastAttackTime = Time.time;
                player.TakeDamage(damageAmount);
            }*/
        }
    }
}
