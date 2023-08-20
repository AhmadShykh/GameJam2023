using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform Camera;
    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.forward);     
    }
}
