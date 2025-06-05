using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // OJO, creo que aca puede dar error asi que cualquier
                                               // cosa cambia el nombre entre "" si la escena tiene otro name 
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego"); // Esto solo deberia funcionar si buildeamos
        Application.Quit();
    }
}
