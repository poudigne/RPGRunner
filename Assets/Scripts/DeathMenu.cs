using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public void RestartGame()
    {
        var gameManager = FindObjectOfType<GameController>();
        gameManager.Reset();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene((int)GameScenes.MainMenu);
    }
	
}
