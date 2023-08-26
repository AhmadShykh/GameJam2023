using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenDamaging : MonoBehaviour
{
	//Settings Variables
    [SerializeField] float PushForce = 5f;
	[Header("Ant Settings")]
	[SerializeField] GameObject WorkerAnt;
	[SerializeField] GameObject ArmyAnt;
	[SerializeField] float YPos = 1.7f;
	[SerializeField] float ZPos = -19.5f;
	[SerializeField] float XNegPos = -6.5f;
	[SerializeField] float XPositivePos = 12.5f;
	[SerializeField] GameObject PeanutObject;
	[SerializeField] GameObject SugarObject;
	[SerializeField] float SugarAmount ;

	[Header("Particle Effects")]
	[SerializeField] GameObject HPHitParticle;
	[SerializeField] float ForceScatter = 5f;

	//Other Varaibles
	public bool HasSugar = false;
	public bool HasPeanut = false;

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
		else if (other.gameObject.tag == "sugar")
		{
			if (!HasSugar)
			{
				HasSugar = true;
				other.gameObject.GetComponent<PlantResources>().DecreaseAmount(1);
				SugarObject.SetActive(true);
			}
		}
		else if (other.gameObject.tag == "flower")
		{
			if(!HasPeanut)
			{
				HasPeanut = true;
				PeanutObject.SetActive(true);
				other.gameObject.GetComponent<PlantResources>().DecreaseAmount(1);
			}
		}
		else if(other.gameObject.tag == "Sugar Deposit")
		{
			if (HasSugar)
			{
				HasSugar = false;
				SugarObject.SetActive(false);
				GameObject.FindGameObjectWithTag("ant storage").GetComponent<StoringSugar>().GiveSugar(SugarAmount);
				SpawnAnt(WorkerAnt);
			}
		}
		else if(other.gameObject.tag == "Peanut Deposit")
		{
			if (HasPeanut)
			{
				HasPeanut = false;
				PeanutObject.SetActive(false);
				SpawnAnt(ArmyAnt);
			}
		}

	}
	void SpawnAnt(GameObject obj)
	{
		float XPos = Random.Range(XNegPos, XPositivePos);
		Instantiate(obj, new Vector3(XPos, YPos, ZPos), Quaternion.Euler(-90, 180, 0));
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
