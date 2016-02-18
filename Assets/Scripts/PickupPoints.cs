using UnityEngine;
using System.Collections;

public class PickupPoints : MonoBehaviour {

    public int scoreToGive;
    private AudioSource coinSound;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
        coinSound.volume = 0.4f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            scoreManager.AddScore(scoreToGive);
            if (coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
                coinSound.Play();

            gameObject.SetActive(false);
        }
    }
}
