using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingSugar : MonoBehaviour
{
    //Speed of Ant
    [SerializeField] float AntSpeed = 10f;
    
    bool FoundSugar, HasSugar;
    Vector3 GoingLocation;
    GameObject StorageLocation;
    [SerializeField] float SugarAmount = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        HasSugar = false;
        FoundSugar = false;
        GoingLocation = transform.position;
        StorageLocation = GameObject.FindGameObjectWithTag("ant storage");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("sugar").Length != 0 || HasSugar) MoveAnt();
    }
    private void MoveAnt()
	{
        if (!FoundSugar)
        {
            findSugar();
        }
        else if (HasSugar)
        {
            DepositSugar();
        }
        transform.position = Vector3.MoveTowards(transform.position, GoingLocation, AntSpeed * Time.deltaTime);
        
    }
    private void SetAntAngle(Vector3 CurPos, Vector3 DesPos)
	{
        Vector3 diff = DesPos - CurPos;
        
        float angle = -Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg + 270;
        Quaternion direction = Quaternion.Euler(-90,0,angle);
        transform.rotation = direction;
    }
    private void DepositSugar()
	{
        GoingLocation = StorageLocation.transform.position;
        SetAntAngle(transform.position, GoingLocation);
    }
    private void findSugar()
	{
		if (GameObject.FindGameObjectsWithTag("sugar").Length != 0 && !HasSugar)
		{
            GoingLocation = GameObject.FindGameObjectWithTag("sugar").GetComponent<Transform>().position;
            SetAntAngle(transform.position, GoingLocation);
            
            
        }
	}
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "sugar")
		{
            if (HasSugar == false)
			{
                Destroy(collision.gameObject);
                HasSugar = true;
                FoundSugar = true;
            }
		}
        else if(collision.gameObject.tag == "ant storage")
		{
            GoingLocation = transform.position;
            FoundSugar = false;
            collision.gameObject.GetComponent<StoringSugar>().GiveSugar(SugarAmount);
            HasSugar = false;
		}
	}
}
