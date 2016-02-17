using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public enum GameScenes
{
    GameScene,
}

public class GameController : MonoBehaviour
{
    public GUITexture textureOverlay;
    public int overlayDepth = 1;
    public Transform platformGenerator;
    public PlayerControl player;


    private Vector3 platformStartPoint;
    private Vector3 playerStartPoint;
    private bool isPaused = false;
    private PlatformDestroyer[] platformList;
    private ScoreManager scoreManager;
    
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;

        //textureOverlay.transform.position = new Vector3(0, 0, overlayDepth);
        //textureOverlay.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
        //textureOverlay.enabled = false;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void Restart()
    {
        SceneManager.LoadScene((int)GameScenes.GameScene);
    }

    bool togglePause()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pause key pressed");
            togglePause();
        }
            
    }

    void OnGUI()
    {
        if (isPaused)
        {
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Click me to unpause"))
                isPaused = togglePause();
        }
    }

    public void Pause()
    {
        isPaused = togglePause();
    }
    
    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);
        for(int i = 0, count = platformList.Length; i < count; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }
}
