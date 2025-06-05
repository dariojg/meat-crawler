using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredienteBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //TODO Se lanza animacion, particulas, sonido, etc. se guarda en inventario de jugador y desaparece.

            Debug.Log("Ingrediente recogido por el jugador...");

            Destroy(gameObject);

            // TODO: Lanzar evento o notificar al jugador que el ingrediente ha sido recogido
            
            // TODO: Lanzar pantalla de Victoria (solo en prototipo)
        }
    }
}
