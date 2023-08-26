using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeesAttacking : MonoBehaviour
{
    GameObject Target;
    [SerializeField] float BeeSpeed = 3f;
    [SerializeField] float YOffset = 0.7f;
    public float Damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("target");
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
		{
            SetAntAngle(Target.transform.position);
            Vector3 TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y + YOffset, Target.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, BeeSpeed * Time.deltaTime);
        }
        
    }

    private void SetAntAngle(Vector3 DesPos)
    {
        Vector3 diff = DesPos - transform.position;
        float angle = -Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg-90;
        Quaternion direction = Quaternion.Euler(0, angle, 0);
        transform.rotation = direction;
    }

}
