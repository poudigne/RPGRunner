using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public enum GameScenes
{
    MainMenu,
    GameScene
}

public class GameController : MonoBehaviour
{
    public GUITexture textureOverlay;
    public int overlayDepth = 1;
    public Transform platformGenerator;
    public PlayerControl player;
    public DeathMenu deathScreen;
    public PauseMenu pauseScreen;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseScreen.TogglePause();
        }
            
    }

    
    
    public void RestartGame()
    {
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);

        deathScreen.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        deathScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0, count = platformList.Length; i < count; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }

    //public IEnumerator RestartGameCo()
    //{
    //    scoreManager.scoreIncreasing = false;
    //    player.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(0.5f);
    //    platformList = FindObjectsOfType<PlatformDestroyer>();
    //    player.transform.position = playerStartPoint;
    //    platformGenerator.position = platformStartPoint;
    //    player.gameObject.SetActive(true);
    //    for(int i = 0, count = platformList.Length; i < count; i++)
    //    {
    //        platformList[i].gameObject.SetActive(false);
    //    }
    //    scoreManager.scoreCount = 0;
    //    scoreManager.scoreIncreasing = true;
    //}
}
