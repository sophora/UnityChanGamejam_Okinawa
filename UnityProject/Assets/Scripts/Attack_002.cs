using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack_002 : AttackBase
{
	protected void OnTriggerStay(Collider other)
	{
		EnemyController aEnemy = other.gameObject.GetComponent<EnemyController>();
		if (aEnemy != null)
		{
			if (!mTargets.Contains(aEnemy))
			{
				mTargets.Enqueue(aEnemy);
			}
		}
	}

	protected override void Update()
	{
		base.Update();

		while(mTargets.Count > 0)
		{
			EnemyController aEnemy = mTargets.Dequeue();
			aEnemy.AddDamage(Damage * Time.deltaTime);
		}
	}

	private void Start()
	{
		mTargets = new Queue<EnemyController>();
	}

	private Queue<EnemyController> mTargets;
}
