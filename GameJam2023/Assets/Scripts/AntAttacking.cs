using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAttacking : MonoBehaviour
{
    GameObject Bee;
    [SerializeField] float BeeSpeed = 5f;
    float AttackingTime = 5f;
    public bool CanAttack;
    float Counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        CanAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindBee())
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
        if (Bee == null)
            return false;
        else
            return true;
    }
    void ResetAttackPower()
	{
	    Counter += Time.;
        if(Counter == AttackingTime)
		{
            CanAttack = true;
            Counter = 0;
		}
	
	}

    private void OnCollisionEnter(Collision collision)
    {
        float ImpulseForce = 10f;
        if (collision.gameObject.tag == "target")
        {
            Debug.Log("Hi");
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * ImpulseForce, ForceMode.Impulse);
        }

    }

    private void SetAntAngle(Vector3 DesPos)
    {
        Vector3 diff = DesPos - transform.position;

        float angle = -Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg - 90;
        Quaternion direction = Quaternion.Euler(0, angle, 0);
        transform.rotation = direction;
    }

}
