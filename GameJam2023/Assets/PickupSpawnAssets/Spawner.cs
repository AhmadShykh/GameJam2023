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
/*
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float MinWait = 6f;
    public float MaxWait = 10f;
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
            
            // Attach a collider to the spawned object (assuming it doesn't have one)
            Collider spawnedCollider = spawnedObject.GetComponent<Collider>();
            if (spawnedCollider == null)
            {
                spawnedCollider = spawnedObject.AddComponent<BoxCollider>();
            }
            
            // Set the spawned object as a trigger so it doesn't cause physics collisions
            spawnedCollider.isTrigger = true;

            // Add a script to handle collision with the player
            spawnedObject.AddComponent<DestroyOnContact>();
        }
    }
}

public class DestroyOnContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

 */