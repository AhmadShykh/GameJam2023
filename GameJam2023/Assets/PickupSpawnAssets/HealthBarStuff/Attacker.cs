using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Attacker : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    private Target targetScript;
    public float pushbackDistance = 3f;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        targetScript = target.GetComponent<Target>();
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        if (targetScript != null)
        {
            targetScript.TakeDamage(20);
        }
        Vector3 pushbackDirection = -transform.forward;
        transform.Translate(pushbackDirection * pushbackDistance, Space.World);
    }
}