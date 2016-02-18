using UnityEngine;
using System.Collections;

public class PickupResources : MonoBehaviour {

    public int quantity;
    public ResourcesType resourceType;

    private AudioSource coinSound;

    private ResourcesManager resourceManager;

    void Start()
    {
        resourceManager = FindObjectOfType<ResourcesManager>();
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
        coinSound.volume = 0.4f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            resourceManager.AddResources(resourceType, quantity);
            gameObject.SetActive(false);
        }
    }
}
