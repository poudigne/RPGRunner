using UnityEngine;
using System.Collections;

public class Powerups : MonoBehaviour
{
    public bool doublePoints;
    public bool safeMode;

    public float powerupLength;

    private PowerupsManager powerupManager;

    public Sprite[] sprites;

    void Awake()
    {
        int powerupSelector = Random.Range(0, 2);

        switch (powerupSelector)
        {
            case 0:
                doublePoints = true;
                break;
            case 1:
                safeMode = true;
                break;
        }
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[powerupSelector];
    }

    void Start()
    {
        powerupManager = FindObjectOfType<PowerupsManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            powerupManager.ActivatePowerup(doublePoints, safeMode, powerupLength);
            gameObject.SetActive(false);

        }

    }

}
