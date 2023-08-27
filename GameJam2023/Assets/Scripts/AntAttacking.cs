using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAttacking : MonoBehaviour
{
    
    //Setting Variables
    [Header("Ant Attacking Settings")]
    [SerializeField] float BeeSpeed = 5f;
    [SerializeField] float YOffset = 0.3f;
    [SerializeField] float AttackingTime = 5f;
    [SerializeField] float AwayDistance = 0.5f;
    public bool CanAttack;
    public float Counter = 0;
    [SerializeField] public float Damage = 3f;
    [SerializeField] public float AntHealth = 12;
    [Header("Ant Animation")]
    [SerializeField] Animator AntAnimator;
    [Header("Ant Particle Effects")]
    [SerializeField] GameObject SwordHitEffect;


    //Other Variables
    GameObject Bee;
    bool IsAttacking;
    // Start is called before the first frame update
    void Start()
    {
        CanAttack = true;
        Bee = GameObject.FindGameObjectWithTag("bee");
    }

    // Update is called once per frame
    void Update()
    {

        if(GameObject.FindGameObjectsWithTag("bee").Length!= 0 && FindBee() )
		{
            SetAntAngle(Bee.transform.position);
            //Checking the bee type using its mass value in rigid body
            //Did it this way because assigned a single tag to all bees beforehand 
            if (Bee.GetComponent<Rigidbody>().mass < 1)
                YOffset = -.2f;
            else
                YOffset = -.3f;
            Vector3 BeePos = new Vector3(Bee.transform.position.x, Bee.transform.position.y + YOffset, Bee.transform.position.z);
            if(Vector3.Distance(transform.position,BeePos) > AwayDistance)
                transform.position = Vector3.MoveTowards(transform.position, BeePos, BeeSpeed * Time.deltaTime);
            AntAnimator.SetBool("Walk", true);
        }
        else
            AntAnimator.SetBool("Walk", false);
        if (!CanAttack)
            ResetAttackPower();
    }
    bool FindBee()
	{
        Bee = GameObject.FindGameObjectWithTag("bee");
        bool IsBeeActive, findBee = false;
        
        if (Bee != null )
		{
            IsBeeActive = Bee.GetComponent<BeeDamaging>().BeeActive;
            if (IsBeeActive)
                findBee = true;
        }

        return findBee;
    }
    void ResetAttackPower()
	{
        Counter += Time.deltaTime;
        if(Counter >= AttackingTime)
		{
            CanAttack = true;
            Counter = 0;
		}
	
	}

    private void SetAntAngle(Vector3 DesPos)
    {
        Vector3 diff = DesPos - transform.position;

        float angle = -Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg - 90;
        Quaternion direction = Quaternion.Euler(0, angle, 0);
        transform.rotation = direction;
    }
    public void AntHitEffect()
	{
        Vector3 LocalPos = new Vector3(transform.localPosition.x, transform.localPosition.y+0.4f, transform.localPosition.z );
        GameObject Particle = Instantiate(SwordHitEffect, LocalPos,transform.rotation);
        Particle.transform.Translate(0, 0, -0.65f);
        //Playing Hit Animation
        AntAnimator.SetTrigger("Attack");
    }
	

}
