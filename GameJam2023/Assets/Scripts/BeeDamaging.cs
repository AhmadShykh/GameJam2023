using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDamaging : MonoBehaviour
{
    [Header("Bee Damaging Parameter")]
    [SerializeField] float TotalHealth = 10f;
    [SerializeField] float PushForce = 4f;
    [SerializeField] float BeeDamage = 4f;
    [Header("Particle Effects")]
    [SerializeField] GameObject HPHitParticle;
    [SerializeField] float ForceScatter = 5f;
    [Header("Audio")]
    [SerializeField] AudioClip hitAudioClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("army ant" ) || other.gameObject.CompareTag("Spider"))
        {
            Vector3 PushPos;
            if (other.gameObject.tag == "army ant") PushPos = Vector3.down;
            else PushPos = Vector3.forward;
            other.gameObject.transform.Translate(PushPos * PushForce);
            AntAttacking AntComponent = other.gameObject.GetComponent<AntAttacking>();
            //Decreasing Bee and Ant value at the same time because Bees wont attack Ants but there health will drop automatically 
            if (AntComponent.CanAttack) {
                TotalHealth -= AntComponent.Damage;
                AntComponent.AntHealth -= BeeDamage;
                AntComponent.CanAttack = false;
                //Apply the Hp effect on both simultaneously 
                ApplyHpParticleEffect(AntComponent.Damage,transform.position,new Color(255,0,0));
                ApplyHpParticleEffect(BeeDamage,other.transform.position,new Color(255,127.5f,0));
            }
            ApplyHpParticleEffect(AntComponent.Damage);
            if (hitAudioClip != null)
            {
                audioSource.PlayOneShot(hitAudioClip);
            }
            if (TotalHealth <= 0)
			{
                Destroy(gameObject);
            else if(AntComponent.AntHealth <= 0)
                Destroy(other.gameObject);

        }
    }
    void ApplyHpParticleEffect(float AntDamage,Vector3 SpawnLocation,Color HPParticleColor)
    {
        Vector3 HPParticlePos = new Vector3(SpawnLocation.x, SpawnLocation.y + 0.3f, SpawnLocation.z);
        GameObject Particle = Instantiate(HPHitParticle, HPParticlePos, transform.rotation);
        Particle.GetComponent<BillBoard>().Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        GameObject HPLabel = Particle.transform.GetChild(0).gameObject;
        HPLabel.GetComponent<TextMesh>().text = "-" + AntDamage.ToString();
        HPLabel.GetComponent<TextMesh>().color = HPParticleColor;
        
    }
}
