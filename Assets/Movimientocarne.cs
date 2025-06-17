using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RuedaGiratoriaUI : MonoBehaviour
{
    public float velocidad = 50f; 

    void Update()
    {
        transform.Rotate(0f, 1f, -velocidad * Time.deltaTime);
    }
}