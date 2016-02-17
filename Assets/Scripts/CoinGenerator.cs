using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

	public void SpawnCoins(Vector3 position)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = position;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(position.x - distanceBetweenCoins, position.y, position.z);
        coin2.SetActive(true);

        GameObject coin3 = coinPool.GetPooledObject();
        coin3.transform.position = new Vector3(position.x + distanceBetweenCoins, position.y, position.z);
        coin3.SetActive(true);
    }
}
