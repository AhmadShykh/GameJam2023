using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Attacker : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float pushbackDistance = 10f;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame+3)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("Attack", true);
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

}