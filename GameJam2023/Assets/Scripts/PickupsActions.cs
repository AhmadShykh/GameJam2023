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
    [Header("Ants Pickups Settings")]
    [SerializeField] GameObject WorkerAnt;
    [SerializeField] GameObject ArmyAnt;
    [SerializeField] float YPos = 1.7f;
    [SerializeField] float ZPos = -19.5f;
    [SerializeField] float XNegPos = -6.5f;
    [SerializeField] float XPositivePos = 12.5f;
    [SerializeField] GameObject PeanutObject;
    [SerializeField] GameObject SugarObject;
    [SerializeField] float SugarAmount;
    [Header("Pickups Particle Effects")]
    [SerializeField] ParticleSystem HealingEffect;
    [SerializeField] ParticleSystem SpeedEffect;
    [SerializeField] GameObject SpiderEffect;
    [Header("Sound Settings")]
    [SerializeField] AudioSource PickupSound;


    //Other Variables
    bool HasSugar = false;
    bool HasPeanut = false;


    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HealingPotion") || other.CompareTag("SpawnSpider")|| other.CompareTag("SpeedPotion")|| other.CompareTag("sugar")
            || other.CompareTag("flower")|| other.CompareTag("Sugar Deposit")|| other.CompareTag("Peanut Deposit"))
		{
            if (other.CompareTag("HealingPotion"))
            {
                Destroy(other.gameObject);
                StartCoroutine(PlayEffect(HealingEffect, HealingEffect.main.duration));
                float CurrentHealth = this.GetComponent<Target>().currentHealth;
                float MaxHealth = this.GetComponent<Target>().MaxHealth;
                if (CurrentHealth + 10 >= MaxHealth)
                    this.GetComponent<Target>().TakeDamage(-(MaxHealth - CurrentHealth));
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
                GameObject spawnedObject = Instantiate(SpiderObject, randomPosition, Quaternion.Euler(0, 0, 0));
            }
            else if (other.CompareTag("SpeedPotion"))
            {
                Destroy(other.gameObject);
                StartCoroutine(PlayEffect(SpeedEffect, 2));
                this.GetComponent<QueenMovement>().IncreaseSpeed(SpeedIncreasedBy);
                StartCoroutine(DecreaseSpeedAfterDelay());
            }
            else if (other.CompareTag("sugar"))
            {
                if (!HasSugar)
                {
                    HasSugar = true;
                    other.gameObject.GetComponent<PlantResources>().DecreaseAmount(1);
                    SugarObject.SetActive(true);
                }
            }
            else if (other.CompareTag("flower"))
            {
                if (!HasPeanut)
                {
                    HasPeanut = true;
                    PeanutObject.SetActive(true);
                    other.gameObject.GetComponent<PlantResources>().DecreaseAmount(1);
                }
            }
            else if (other.CompareTag("Sugar Deposit"))
            {
                if (HasSugar)
                {
                    HasSugar = false;
                    SugarObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("ant storage").GetComponent<StoringSugar>().GiveSugar(SugarAmount);
                    SpawnAnt(WorkerAnt);
                }
            }
            else if (other.CompareTag("Peanut Deposit"))
            {
                if (HasPeanut)
                {
                    HasPeanut = false;
                    PeanutObject.SetActive(false);
                    SpawnAnt(ArmyAnt);
                }
            }
            PickupSound.Play();
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
    void SpawnAnt(GameObject obj)
    {
        float XPos = Random.Range(XNegPos, XPositivePos);
        Instantiate(obj, new Vector3(XPos, YPos, ZPos), Quaternion.Euler(-90, 180, 0));
    }
}
