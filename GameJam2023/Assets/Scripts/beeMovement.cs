using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    float xMover;
    float zMover;
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
        transform.Translate(xMover,0,zMover);
    }
}
