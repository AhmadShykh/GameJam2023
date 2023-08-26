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
    [Header("Worker Ant Animation")]
    [SerializeField] Animator AntAnimator;
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
        if (GameObject.FindGameObjectsWithTag("sugar").Length != 0 || HasSugar) MoveAnt();
        else AntAnimator.SetBool("Walk", false);
    }
    private void MoveAnt()
	{
        AntAnimator.SetBool("Walk", true);
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
        Quaternion direction = Quaternion.Euler(0, angle,0);
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
	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "sugar")
        {
            if (HasSugar == false)
            {
                other.gameObject.GetComponent<PlantResources>().DecreaseAmount(1);
                HasSugar = true;
                FoundSugar = true;
            }
        }
        else if (other.gameObject.tag == "ant storage")
        {
            GoingLocation = transform.position;
            FoundSugar = false;
            other.gameObject.GetComponent<StoringSugar>().GiveSugar(SugarAmount);
            HasSugar = false;
        }
    }
	
}
