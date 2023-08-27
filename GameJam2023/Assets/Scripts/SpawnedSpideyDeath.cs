using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedSpideyDeath : MonoBehaviour
{
    public float killAfter = 5f;
    void Start()
    {
        StartCoroutine(Death());
    }
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(killAfter);
        StartCoroutine(gameObject.GetComponent<AntAttacking>().AntDeathSequence());
    }
}
