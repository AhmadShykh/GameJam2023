using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixAngle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.AngleAxis(-90,Vector3.right);
    }
}
