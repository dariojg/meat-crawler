using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego"); // Esto solo deberia funcionar si buildeamos
        Application.Quit();
    }
}
