using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public ObjectPooler[] poolers;
    public ObjectPooler spikePool;
    public ObjectPooler powerupPool;

    public Transform generationPoint;
    public Transform maxHeightPoint;

    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float maxHeightChange;
    public float powerupHeight;

    public float randomCoinThreshold;
    public float randomSpikeThreshold;
    public float powerupThreshold;
    public float randomVerticalSpawnThreshold;

    private float distanceBetween;
    private int platformSelector;
    private float[] platformWidths;
    private float minHeight;
    private float maxHeight;
    private float heightChange;
    private float resourceHeightChange;
    private Vector3 lastPlatformPos = new Vector3(0,0,0);

    
    private ResourcesGenerator coinGenerator;



    // Use this for initialization
    void Start ()
    {
        platformWidths = new float[poolers.Length];
        for(int i = 0; i < poolers.Length; i++)
        {
            platformWidths[i] = poolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        coinGenerator = FindObjectOfType<ResourcesGenerator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.position.x < generationPoint.position.x)
        {
            platformSelector = Random.Range(0, poolers.Length - 1);
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            heightChange = Mathf.Clamp(heightChange, minHeight, maxHeight);

            if(Random.Range(0.0f,100f) < powerupThreshold)
            {
                GameObject powerup = powerupPool.GetPooledObject();
                powerup.transform.position = transform.position + new Vector3(distanceBetween / 2f, Random.Range(0.0f,powerupHeight), transform.position.z);
                powerup.transform.rotation = transform.rotation;
                powerup.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            var pooledObject = poolers[platformSelector].GetPooledObject();
            pooledObject.transform.position = transform.position;
            pooledObject.transform.rotation = transform.rotation;
            pooledObject.SetActive(true);


            if(Random.Range(0f,100f) < randomCoinThreshold)
            {
                coinGenerator.SpawnResources(new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Mathf.RoundToInt(platformWidths[platformSelector]));
            }
            if(Random.Range(0f,100f) < randomVerticalSpawnThreshold)
            {
                var distance = new Vector3((pooledObject.transform.position.x + lastPlatformPos.x) / 2, (pooledObject.transform.position.y + lastPlatformPos.y) / 2, transform.position.z);
                coinGenerator.SpawnResourcesVerticaly(distance);
            }
            lastPlatformPos = pooledObject.transform.position;

            if(Random.Range(0f,100f) < randomSpikeThreshold)
            {
                GameObject spike = spikePool.GetPooledObject();
                float platformHalf = platformWidths[platformSelector] / 2;
                float spikeXPos = Random.Range(-platformHalf + 1f, platformHalf -1f);

                Vector3 spikePosition = new Vector3(spikeXPos, pooledObject.GetComponent<BoxCollider2D>().size.y / 2, 0.0f);
                spike.transform.position = transform.position + spikePosition;
                spike.transform.rotation = transform.rotation;
                spike.SetActive(true);
            }
            
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
	}
}
