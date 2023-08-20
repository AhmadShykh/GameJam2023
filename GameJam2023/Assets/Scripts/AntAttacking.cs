using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAttacking : MonoBehaviour
{
    GameObject Bee;
    [SerializeField] float BeeSpeed = 5f;
    [SerializeField] float AttackingTime = 5f;
    public bool CanAttack;
    public float Counter = 0;
    [SerializeField] public float Damage = 3f;
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
}
