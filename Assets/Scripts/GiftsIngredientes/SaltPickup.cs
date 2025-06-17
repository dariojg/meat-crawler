using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Sal recogida");
            Destroy(gameObject);
        }
    }
}
