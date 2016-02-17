using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    // public ObjectPooler pooler;
    public GameObject[] platforms;
    public Transform generationPoint;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private float distanceBetween;
    private int platformSelector;
    private float[] platformWidths;

    // Use this for initialization
    void Start ()
    {
        platformWidths = new float[platforms.Length];
        for(int i = 0; i < platforms.Length; i++)
        {
            platformWidths[i] = platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.position.x < generationPoint.position.x)
        {
            platformSelector = Random.Range(0, platforms.Length - 1);
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, transform.position.y, transform.position.z);
            Instantiate(platforms[platformSelector], transform.position, transform.rotation);

            //var pooledObject = pooler.GetPooledObject();
            //pooledObject.transform.position = transform.position;
            //pooledObject.transform.rotation = transform.rotation;
            //pooledObject.SetActive(true);
        }
	}
}
