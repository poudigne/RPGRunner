using UnityEngine;
using System.Collections;

public class ResourcesGenerator : MonoBehaviour
{
    public ObjectPooler[] resourcePool;

    public float distanceBetweenResources;

	public void SpawnResources(Vector3 position, int width)
    {
        var pooler = resourcePool[Random.Range(0,resourcePool.Length)];
        GameObject coin1 = pooler.GetPooledObject();
        coin1.transform.position = position;
        coin1.SetActive(true);

        GameObject coin2 = pooler.GetPooledObject();
        coin2.transform.position = new Vector3(position.x - distanceBetweenResources, position.y, position.z);
        coin2.SetActive(true);

        GameObject coin3 = pooler.GetPooledObject();
        coin3.transform.position = new Vector3(position.x + distanceBetweenResources, position.y, position.z);
        coin3.SetActive(true);
    }
    public void SpawnResourcesVerticaly(Vector3 position)
    {
        var pooler = resourcePool[Random.Range(0, resourcePool.Length)];
        GameObject coin1 = pooler.GetPooledObject();
        coin1.transform.position = position;
        coin1.SetActive(true);

        GameObject coin2 = pooler.GetPooledObject();
        coin2.transform.position = new Vector3(position.x, position.y - distanceBetweenResources, position.z);
        coin2.SetActive(true);

        GameObject coin3 = pooler.GetPooledObject();
        coin3.transform.position = new Vector3(position.x, position.y + distanceBetweenResources, position.z);
        coin3.SetActive(true);
    }
}
