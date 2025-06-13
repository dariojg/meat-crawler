using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [Header("Pez y posición de lanzamiento")]
    public GameObject fishPrefab;
    public Transform spawnPoint;

    [Header("Fuerza de lanzamiento")]
    public float force = 10f;

    private bool fishSpawned = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !fishSpawned)
        {
            SpawnFish();
            fishSpawned = true;
        }
    }

    void SpawnFish()
    {
        if (fishPrefab == null || spawnPoint == null)
        {
            Debug.LogWarning("Asigná el prefab del pescado y el punto de spawn en el inspector.");
            return;
        }

        GameObject fish = Instantiate(fishPrefab, spawnPoint.position, spawnPoint.rotation);

        Rigidbody rb = fish.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spawnPoint.forward * force, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("El prefab del pescado no tiene un Rigidbody. Agregale uno.");
        }
    }
}
