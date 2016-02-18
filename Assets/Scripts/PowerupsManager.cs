using UnityEngine;
using System.Collections;


public class PowerupsManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;
    private float powerLengthCounter;

    private ScoreManager scoreManager;
    private PlatformGenerator platformGenerator;
    private GameController gameManager;

    private float spikeRate;
    private float normalPointsPerSecond;

    private PlatformDestroyer[] spikeList;

    // Use this for initialization
    void Start ()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        platformGenerator = FindObjectOfType<PlatformGenerator>();
        gameManager = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (powerupActive)
        {
            powerLengthCounter -= Time.deltaTime;

            if (gameManager.powerupReset)
            {
                powerLengthCounter = 0;
                powerupActive = false;
                gameManager.powerupReset = false;
            }

            if (doublePoints)
            {
                scoreManager.shouldDouble = true;
            }

            if (safeMode)
            {
                platformGenerator.randomSpikeThreshold = 0.0f;
                spikeList = FindObjectsOfType<PlatformDestroyer>();
                for (int i = 0, count = spikeList.Length; i < count; i++)
                {
                    if(spikeList[i].gameObject.name.Contains("spikes"))
                        spikeList[i].gameObject.SetActive(false);
                }
            }
                
            if (powerLengthCounter <= 0)
            {
                scoreManager.pointsPerSecond = normalPointsPerSecond;
                platformGenerator.randomSpikeThreshold = spikeRate;
                scoreManager.shouldDouble = false;
                safeMode = false;
                doublePoints = false;
            }
        }

	}

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;

        normalPointsPerSecond = scoreManager.pointsPerSecond;
        spikeRate = platformGenerator.randomSpikeThreshold;

        powerLengthCounter = time;
        powerupActive = true;
    }
}
