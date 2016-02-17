using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
            PauseGame();
        else
            ResumeGame();
        gameObject.SetActive(isPaused);
    }

    void PauseGame()
    {
        
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        var gameController = FindObjectOfType<GameController>();
        gameController.Reset();
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene((int)GameScenes.MainMenu);
    }
}
