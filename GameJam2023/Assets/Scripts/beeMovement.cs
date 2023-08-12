using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class beeMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    float xMover, zMover, yaw;
    [SerializeField] float beeSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xMover = joystick.Horizontal * beeSpeed * Time.deltaTime;
        zMover = joystick.Vertical* beeSpeed * Time.deltaTime;
        if(joystick.Vertical!=0 && joystick.Horizontal!=0) yaw = -((Mathf.Atan2(joystick.Vertical, joystick.Horizontal)*180)/ Mathf.PI);
        transform.rotation = Quaternion.Euler(0,yaw,0) ;
        transform.Translate(xMover,0, zMover,Space.World);
    }
}
