using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawning : MonoBehaviour
{

    public int WaveNum = 0;
    public float timeDelay = 5f;
    [Header("Bees Spawn Setings")]
    [SerializeField] GameObject smallBee;
    [SerializeField] GameObject bigBee;
    [SerializeField] float YPos = 1.7f;
    [SerializeField] float ZPos = 16.5f;
    [SerializeField] float XNegPos = -6.5f;
    [SerializeField] float XPositivePos = 12.5f;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        while (true)
        {
            SpawnWave(WaveNum);
            WaveNum++;

            yield return new WaitForSeconds(timeDelay);
        }
    }
    void SpawnWave(int waveNum)
    {
        int smallBeesCount = (2 * (waveNum)) + 1;
        int bigBeesCount = waveNum;

        for (int i = 0; i < smallBeesCount; i++)
        {
            SpawnBee(smallBee);
        }

        for (int i = 0; i < bigBeesCount; i++)
        {
            SpawnBee(bigBee);
        }
    }

    void SpawnBee(GameObject beeToSpawn)
    {
        if (beeToSpawn == bigBee)
            YPos = 1.87f;
        Vector3 randomPosition = new Vector3(Random.Range(XNegPos, XPositivePos), YPos, ZPos);
        Instantiate(beeToSpawn, randomPosition, Quaternion.Euler(-90,0,0));
    }
}