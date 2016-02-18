using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreValueText;
    public Text highscoreValueText;

    public GameObject player;

    public float scoreCount;
    public float highscoreCount;
    public float pointsPerSecond;

    public bool scoreIncreasing;

    public bool shouldDouble;
	// Use this for initialization
	void Start () {
        scoreValueText.text = "0";

        if (PlayerPrefs.HasKey("HighScore"))
            highscoreCount = PlayerPrefs.GetFloat("HighScore");
	}
	
	// Update is called once per frame
	void Update () {
        if (!scoreIncreasing)
            return;
        //scoreValueText.text = Mathf.RoundToInt(player.transform.position.x).ToString();
        AddScore(pointsPerSecond * Time.deltaTime);
        scoreValueText.text = "Score: " + Mathf.Round(scoreCount);
        if (scoreCount > highscoreCount)
        {
            highscoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highscoreCount);
        }
        highscoreValueText.text = "High score: " + Mathf.RoundToInt(highscoreCount);
    }

    public void AddScore(float amount)
    {
        if (shouldDouble)
            amount *= 2;
        scoreCount += amount;
    }
}
