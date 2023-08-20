using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float MinWait = 6f;
    public float MaxWait = 10f;
    public float DestoryWait = 5f;
    [SerializeField] float XPosRange = 0f;
    [SerializeField] float XNegRange = 0f;
    [SerializeField] float ZPosRange = 0f;
    [SerializeField] float ZNegRange = 0f;
    [SerializeField] float YRange = 0f;
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
            Vector3 randomPosition = new Vector3(Random.Range(XNegRange, XPosRange), YRange, Random.Range(ZNegRange, ZPosRange));
            GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.Euler(-90,0,0));
            Destroy(spawnedObject, DestoryWait);
        }
    }
}