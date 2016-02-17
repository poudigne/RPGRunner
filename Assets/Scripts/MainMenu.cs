using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void StartGame()
    {
        SceneManager.LoadScene((int)GameScenes.GameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
