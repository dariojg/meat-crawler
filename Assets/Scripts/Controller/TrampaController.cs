using System.Collections;
using UnityEngine;

public class TrampaController : MonoBehaviour
{
    public TrampaDisparo[] trampas;
    public float intervalo = 15f;

    private void Start()
    {
        StartCoroutine(CicloDisparos());
    }

    IEnumerator CicloDisparos()
    {
        while (true)
        {
            for (int i = 0; i < trampas.Length; i++)
            {
                trampas[i].Disparar();
                yield return new WaitForSeconds(intervalo);
            }
        }
    }
}
