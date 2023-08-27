using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDamage : MonoBehaviour
{
    public bool CanAttack = true;
    [SerializeField] float WaitTime = 2f;
	public float SpikeDamage = 5f;
	
	public IEnumerator ResetAttackPower()
	{
		yield return new WaitForSeconds(WaitTime);
		CanAttack = true;
	}
}
