using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider : MonoBehaviour
{
    public GameObject Spidey;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("target"))
        {
            Destroy(gameObject);
            Vector3 randomPosition = new Vector3(
                Random.Range(-5.8f, 5.8f),
                1f,
                Random.Range(-10.18f, 10.18f)
            );
            GameObject spawnedObject = Instantiate(Spidey, randomPosition, Quaternion.identity);
        }
    }
}