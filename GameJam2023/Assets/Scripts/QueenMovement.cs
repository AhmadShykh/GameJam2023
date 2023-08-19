using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    float xMover, yMover, yaw;
    [SerializeField] float QueenSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        xMover = -joystick.Horizontal * QueenSpeed * Time.deltaTime;
        yMover = joystick.Vertical * QueenSpeed * Time.deltaTime;
        if (joystick.Vertical != 0 && joystick.Horizontal != 0) yaw = -((Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * 180) / Mathf.PI);
        transform.rotation = Quaternion.Euler(-90, yaw-90, 0);
        transform.parent.Translate(xMover, yMover, 0);
    }

    public void IncreaseSpeed(float speed) => QueenSpeed += speed;

}
