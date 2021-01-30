using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasManager : MonoBehaviour
{
    public GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { PauseGame(); }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }
}
