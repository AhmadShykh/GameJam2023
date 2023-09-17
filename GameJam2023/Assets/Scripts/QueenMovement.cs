using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    float xMover, zMover, yaw = 90;
    [SerializeField] Animator QueenAnimation;
    [SerializeField] float QueenSpeed = 10f;
    [SerializeField] float RotateSpeed = 360f;
    
    

    // Update is called once per frame
    void Update()
    {
        xMover = joystick.Horizontal * QueenSpeed * Time.deltaTime;
        zMover = joystick.Vertical * QueenSpeed * Time.deltaTime;
        if (joystick.Vertical != 0 || joystick.Horizontal != 0)
        {
            QueenAnimation.SetBool("Walk", true);
            yaw = -((Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * 180) / Mathf.PI);
        }
        else
		{
            QueenAnimation.SetBool("Walk", false);
        }
        Quaternion RotatingTowards = Quaternion.Euler(0, yaw-90, 0);
        Quaternion MovingRotation = Quaternion.RotateTowards(transform.rotation, RotatingTowards, RotateSpeed * Time.deltaTime);
        transform.rotation = MovingRotation;
        
        transform.Translate(xMover, 0, zMover, Space.World);
    }

    public void IncreaseSpeed(float speed) => QueenSpeed += speed;
	
	private void OnCollisionEnter(Collision other)
	{
        if (other.gameObject.tag == "Boundary")
        {
            transform.position = transform.position;
        }
    }
	
}
