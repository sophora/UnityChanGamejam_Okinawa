using UnityEngine;
using System.Collections;

public class AttackBase : MonoBehaviour
{
	public float Damage;
	public float ShotSpeed;
	public float LifeTime;
	public float CoolDown;

	protected virtual void Update()
	{
		mSeconds += Time.deltaTime;

		if (LifeTime > 0.0f)
		{
			if (mSeconds >= LifeTime)
			{
				Destroy(gameObject);
			}
		}
	}

	private float mSeconds;
}
