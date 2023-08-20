using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    float xMover, zMover, yaw;
    [SerializeField] float QueenSpeed = 10f;
    [SerializeField] float RotateSpeed = 360f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(-90, 0, -90);
    }

    // Update is called once per frame
    void Update()
    {
        xMover = joystick.Horizontal * QueenSpeed * Time.deltaTime;
        zMover = joystick.Vertical * QueenSpeed * Time.deltaTime;
        if (joystick.Vertical != 0 && joystick.Horizontal != 0) yaw = -((Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * 180) / Mathf.PI);
        Quaternion RotatingTowards = Quaternion.Euler(-90, yaw - 90, 0);
        Quaternion MovingRotation = Quaternion.RotateTowards(transform.rotation, RotatingTowards, RotateSpeed * Time.deltaTime);
        transform.rotation = MovingRotation;
        transform.Translate(xMover, 0, zMover,Space.World);
    }

    public void IncreaseSpeed(float speed) => QueenSpeed += speed;

}
