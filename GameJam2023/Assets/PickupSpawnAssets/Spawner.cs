using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float MinWait = 6f;
    public float MaxWait = 10f;
    public float DestoryWait = 5f;
    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            float interval = Random.Range(MinWait, MaxWait);
            yield return new WaitForSeconds(interval);
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Vector3 randomPosition = new Vector3(
                Random.Range(-5.8f, 5.8f),
                1f,
                Random.Range(-10.18f, 10.18f) 
            );
            GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            Destroy(spawnedObject, DestoryWait);
        }
    }
}