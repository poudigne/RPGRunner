using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public ObjectPooler[] poolers;
    public Transform generationPoint;
    public Transform maxHeightPoint;

    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float maxHeightChange;

    private float distanceBetween;
    private int platformSelector;
    private float[] platformWidths;
    private float minHeight;
    private float maxHeight;
    private float heightChange;
    

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
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            var pooledObject = poolers[platformSelector].GetPooledObject();
            pooledObject.transform.position = transform.position;
            pooledObject.transform.rotation = transform.rotation;
            pooledObject.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
	}
}
