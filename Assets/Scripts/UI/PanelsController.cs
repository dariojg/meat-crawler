using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelsController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
        defeatPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !victoryPanel.activeSelf && !defeatPanel.activeSelf)
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowDefeat()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
