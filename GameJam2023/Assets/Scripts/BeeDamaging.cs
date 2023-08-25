using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDamaging : MonoBehaviour
{
    [SerializeField] float TotalHealth = 10f;
    [SerializeField] float PushForce = 4f;
    [Header("Particle Effects")]
    [SerializeField] GameObject HPHitParticle;
    [SerializeField] float ForceScatter = 5f;
    [Header("Audio")]
    [SerializeField] AudioSource hitAudioClip;
    [SerializeField] AudioSource deathOfBeeAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("army ant" ) || other.gameObject.CompareTag("Spider"))
        {
            Vector3 PushPos;
            if (other.gameObject.tag == "army ant") PushPos = Vector3.down;
            else PushPos = Vector3.forward;
            other.gameObject.transform.Translate(PushPos * PushForce);
            AntAttacking AntComponent = other.gameObject.GetComponent<AntAttacking>();
            if (AntComponent.CanAttack) {
                TotalHealth -= AntComponent.Damage;
                AntComponent.CanAttack = false;
            }
            ApplyHpParticleEffect(AntComponent.Damage);
            if (hitAudioClip != null)
            {
                hitAudioClip.Play();
            }
            if (TotalHealth <= 0)
			{
                if(deathOfBeeAudioClip!=null)
                {
                    deathOfBeeAudioClip.Play();
                }
                Destroy(gameObject);
			}

        }
    }
    void ApplyHpParticleEffect(float AntDamage)
    {
        Vector3 ParticlePos = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);
        GameObject Particle = Instantiate(HPHitParticle, transform.position, transform.rotation);
        Particle.GetComponent<BillBoard>().Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        GameObject HPLabel = Particle.transform.GetChild(0).gameObject;
        HPLabel.GetComponent<TextMesh>().text = "-" + AntDamage.ToString();
        HPLabel.GetComponent<TextMesh>().color = new Color(255, 0, 0);
        Particle.GetComponent<Rigidbody>().AddForce(new Vector3(ParticlePos.x + Random.Range(-ForceScatter, ForceScatter), ParticlePos.y + Random.Range(-ForceScatter, ForceScatter), ParticlePos.z + Random.Range(-ForceScatter, ForceScatter)));
    }
}
