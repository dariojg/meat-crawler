using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    public float force = 10f;
    public string playerTag = "Player";

    private Rigidbody rb;
    private bool launched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null && !launched)
        {
            
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            launched = true;
        }
        else if (rb == null)
        {
            Debug.LogWarning("El pescado necesita un Rigidbody.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró en trigger con: " + other.name);

        if (other.CompareTag(playerTag))
        {
            Debug.Log("Pez recogido por el jugador");
            Destroy(gameObject);
        }
    }
}
