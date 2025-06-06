using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("MenuScreen"); 
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
