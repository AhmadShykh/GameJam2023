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
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, BeeSpeed* Time.deltaTime);
    }

	
    private void OnTri(Collision collision)
	{
		if(collision.gameObject.tag == "target")
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back*10,ForceMode.Impulse);
		
	}

}
