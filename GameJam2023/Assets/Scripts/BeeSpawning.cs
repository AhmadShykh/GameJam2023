using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawning : MonoBehaviour
{
    public GameObject smallBee;
    public GameObject bigBee;
    public int WaveNum = 0;
    public float timeDelay = 5f;
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
        int smallBeesCount = (2 * (waveNum+1)) + 1;
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
        Vector3 randomPosition = new Vector3(
            Random.Range(-5.8f, 5.8f),
            1f,
            Random.Range(9f, 6f)
        );
        Instantiate(beeToSpawn, randomPosition, Quaternion.identity);
    }
}