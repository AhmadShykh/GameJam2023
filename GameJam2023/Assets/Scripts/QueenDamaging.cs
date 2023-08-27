using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenDamaging : MonoBehaviour
{
	//Settings Variables

    [SerializeField] float PushForce = 5f;
	[Header("Particle Effects")]
	[SerializeField] GameObject HPHitParticle;
	[SerializeField] float ForceScatter = 5f;

	//Other Varaibles
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "bee")
		{
			//Apply PushForce and Taking Damage
			other.gameObject.transform.Translate(new Vector3(0,0,1) * PushForce);
			float BeeDamage = other.gameObject.GetComponent<BeesAttacking>().Damage;
			gameObject.GetComponent<Target>().TakeDamage(BeeDamage);
			//Apply HP Particle Effect
			ApplyHpParticleEffect(BeeDamage);
		}
		

	}
	
	void ApplyHpParticleEffect(float BeeDamage)
	{
		Vector3 ParticlePos = new Vector3(transform.position.x , transform.position.y + 3f, transform.position.z );
		GameObject Particle = Instantiate(HPHitParticle, ParticlePos, transform.rotation);
		Particle.GetComponent<BillBoard>().Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		GameObject HPLabel = Particle.transform.GetChild(0).gameObject;
		HPLabel.GetComponent<TextMesh>().text = "-"+BeeDamage.ToString();
		HPLabel.GetComponent<TextMesh>().color = new Color(255,255,0);
		Particle.GetComponent<Rigidbody>().AddForce(new Vector3(ParticlePos.x + Random.Range(-ForceScatter, ForceScatter), ParticlePos.y + Random.Range(-ForceScatter, ForceScatter), ParticlePos.z + Random.Range(-ForceScatter, ForceScatter)));
	}
}
