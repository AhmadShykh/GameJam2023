using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Pickups Spawn Settings")]
    public GameObject[] objectsToSpawn;
    public float MinWait = 6f;
    public float MaxWait = 10f;
    public float DestoryWait = 5f;
    [Header("Plants Spawn Settings ")]
    [SerializeField] float TimeToSpawn = 10f;
    [SerializeField] GameObject ArmyAntPlant;
    [SerializeField] Transform PlantParent;
    [SerializeField] int MaxSpawnInLevel = 10;
    [SerializeField] float YValue = 5.684f;
    [Header("Parameters to Spawn in")]
    [SerializeField] float XPosRange = 0f;
    [SerializeField] float XNegRange = 0f;
    [SerializeField] float ZPosRange = 0f;
    [SerializeField] float ZNegRange = 0f;
    [SerializeField] float YRange = 0f;
    private void Start()
    {
        StartCoroutine(SpawnPickups());
        StartCoroutine(SpawnPlants());
    }

    private IEnumerator SpawnPickups()
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
    private IEnumerator SpawnPlants()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeToSpawn);
            if(GameObject.FindGameObjectsWithTag("flower").Length < MaxSpawnInLevel)
			{
                Vector3 randomPosition = new Vector3(Random.Range(XNegRange, XPosRange), YValue, Random.Range(ZNegRange, ZPosRange));
                GameObject spawnedObject = Instantiate(ArmyAntPlant, randomPosition, Quaternion.Euler(-90, 0, 0), PlantParent);
            }
        }
    }
}