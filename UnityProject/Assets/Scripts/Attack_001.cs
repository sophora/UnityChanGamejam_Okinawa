using UnityEngine;
using System.Collections;

public class Attack_001 : AttackBase
{
	protected void OnTriggerEnter(Collider other)
	{
		EnemyController aEnemy = other.gameObject.GetComponent<EnemyController>();
		if (aEnemy != null && !aEnemy.IsDead())
		{
			aEnemy.AddDamage(Damage);
			Destroy(gameObject);
		}
	}
}
