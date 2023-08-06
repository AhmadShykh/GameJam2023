using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float MinWait = 15f;
    public float MaxWait = 30f;
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
                Random.Range(-50f, 50f),
                3f,
                Random.Range(-50f, 50f) 
            );
            GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            Destroy(spawnedObject, DestoryWait);
        }
    }
}