using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeesAttacking : MonoBehaviour
{
    GameObject Target;
    [SerializeField] float BeeSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("target");
        
    }

    // Update is called once per frame
    void Update()
    {
        SetAntAngle(Target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, BeeSpeed* Time.deltaTime);
    }

	
    private void OnCollisionEnter(Collision collision)
	{
        float ImpulseForce = 10f;
        if (collision.gameObject.tag == "target")
		{
            Debug.Log("Hi");
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*ImpulseForce, ForceMode.Impulse);
        }
            
	}

    private void SetAntAngle(Vector3 DesPos)
    {
        Vector3 diff = DesPos - transform.position;

        float angle = -Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg-90 ;
        Quaternion direction = Quaternion.Euler(0, angle, 0);
        transform.rotation = direction;
    }

}
