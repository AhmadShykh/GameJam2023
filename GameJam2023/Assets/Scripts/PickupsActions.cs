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
    [Header("Pickups Particle Effects")]
    [SerializeField] ParticleSystem HealingEffect;
    [SerializeField] ParticleSystem SpeedEffect;
    [SerializeField] GameObject SpiderEffect;
    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealingPotion"))
        {
            Destroy(other.gameObject);
            StartCoroutine(PlayEffect(HealingEffect, HealingEffect.main.duration));
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
            Instantiate(SpiderEffect, randomPosition, Quaternion.Euler(0, 0, 0));
            GameObject spawnedObject = Instantiate(SpiderObject, randomPosition, Quaternion.Euler(0,0,0));
        }
        else if (other.CompareTag("SpeedPotion"))
        {
            Destroy(other.gameObject);
            StartCoroutine(PlayEffect(SpeedEffect, 2));
            this.GetComponent<QueenMovement>().IncreaseSpeed(SpeedIncreasedBy);
            StartCoroutine(DecreaseSpeedAfterDelay());
        }
        
    }
    private IEnumerator DecreaseSpeedAfterDelay()
    {
        yield return new WaitForSeconds(DecreaseSpeedAfter);
        this.GetComponent<QueenMovement>().IncreaseSpeed(-SpeedIncreasedBy);
    }
    IEnumerator PlayEffect(ParticleSystem ParticleEffect, float WaitFor)
	{
        ParticleEffect.Play();
        yield return new WaitForSeconds(WaitFor);
        ParticleEffect.Stop();

    }
}
