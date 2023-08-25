using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAttacking : MonoBehaviour
{
    GameObject Bee;
    [Header("Ant Attacking Settings")]
    [SerializeField] float BeeSpeed = 5f;
    [SerializeField] float AttackingTime = 5f;
    public bool CanAttack;
    public float Counter = 0;
    [SerializeField] public float Damage = 3f;
    [SerializeField] public float AntHealth = 12;
    [SerializeField] ParticleSystem SwordHitEffect;
    // Start is called before the first frame update
    void Start()
    {
        CanAttack = true;
        Bee = GameObject.FindGameObjectWithTag("bee");
    }

    // Update is called once per frame
    void Update()
    {

        if(GameObject.FindGameObjectsWithTag("bee").Length!= 0 && FindBee())
		{
            SetAntAngle(Bee.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, Bee.transform.position, BeeSpeed * Time.deltaTime);
        }
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
        float YAngle = 0f;
        if (this.CompareTag("army ant"))
            YAngle = -90;
        Quaternion direction = Quaternion.Euler(YAngle, angle, 0);
        transform.rotation = direction;
    }
    public IEnumerator AntHitEffect()
	{
        SwordHitEffect.Play();
        yield return new WaitForSeconds(SwordHitEffect.main.duration);
        SwordHitEffect.Stop();
    }
}
