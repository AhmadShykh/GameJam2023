using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsActions : MonoBehaviour
{
    [Header("Healing Potion Settings")]
    [SerializeField] float HealingValue = 10f;
    [Header("Spider Potion Settings")]
    [SerializeField] GameObject SpiderObject;
    [SerializeField] float XSpawn = 15f;
    [SerializeField] float ZSpawn = 25f;
    [SerializeField] float YSpawn = 1.01f;
    [Header("Speed Potion Settings")]
    [SerializeField] float SpeedIncreasedBy = 3f;
    [SerializeField] float DecreaseSpeedAfter = 4f;
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealingPotion"))
        {
            Destroy(other.gameObject);
            float CurrentHealth = this.GetComponent<Target>().currentHealth;
            float MaxHealth = this.GetComponent<Target>().MaxHealth;
            if (CurrentHealth + 10 >= MaxHealth)
                this.GetComponent<Target>().TakeDamage(-(MaxHealth-CurrentHealth));
            else
                this.GetComponent<Target>().TakeDamage(-HealingValue);
        }
        else if (other.CompareTag("SpawnSpider"))
        {
            Destroy(other.gameObject);
            Vector3 randomPosition = new Vector3(
                Random.Range(-XSpawn, XSpawn),
                YSpawn,
                Random.Range(-ZSpawn, ZSpawn)
            );
            GameObject spawnedObject = Instantiate(SpiderObject, randomPosition, Quaternion.Euler(0,0,0));
        }
        else if (other.CompareTag("SpeedPotion"))
        {
            Destroy(other.gameObject);
            this.GetComponent<QueenMovement>().IncreaseSpeed(SpeedIncreasedBy);
            StartCoroutine(DecreaseSpeedAfterDelay());
        }
        
    }
    private IEnumerator DecreaseSpeedAfterDelay()
    {
        yield return new WaitForSeconds(DecreaseSpeedAfter);
        this.GetComponent<QueenMovement>().IncreaseSpeed(-SpeedIncreasedBy);
    }
}
