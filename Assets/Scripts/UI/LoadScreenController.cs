using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenController : MonoBehaviour
{
    public string nextSceneName = "MenuScreen"; // Nombre de la siguiente scene

    void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        //tiempo
        yield return new WaitForSeconds(3f);

        //Carga la siguiente scene
        SceneManager.LoadScene(nextSceneName);
    }
}
