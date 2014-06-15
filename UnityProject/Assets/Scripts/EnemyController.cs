using UnityEngine;
using System.Collections;

//[ RequireComponent(typeof(AudioSource))]

public class EnemyController : MonoBehaviour
{
	public int        ScorePoint;
	public GameObject EnemyDead;
	public GameObject DeathEffect;
	public float Speed = 1.0f;
	public float attackpower = 1.0f;
	public float enemyhealth = 1.0f;

	public bool IsDead() { return enemyhealth <= 0.0f; }

	public bool AddDamage(float iDamage)
	{
		if (IsDead()) { return true; }

		enemyhealth -= iDamage;
		if (enemyhealth < 0.0f) { enemyhealth = 0.0f; }

		if (IsDead())
		{
			ScoreManager aScoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
			if (aScoreManager != null)
			{
				aScoreManager.AddScore(ScorePoint);
			}
			StartCoroutine(DeadProcess());
		}
		return IsDead();
	}

	private IEnumerator DeadProcess()
	{
		if (!IsDead()) { yield break; }
		mIsDeadProcess = true;
		Instantiate (EnemyDead, Vector3.zero,Quaternion.identity);
		Instantiate (DeathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void FixedUpdate()
	{
		if (IsDead()) { return; }

		transform.LookAt(Vector3.zero);

		Vector3 aPosition = Vector3.zero - transform.localPosition;

		transform.localPosition = transform.localPosition + (aPosition.normalized * Speed * Time.fixedDeltaTime);

		float distance= Vector3.Distance(Vector3.zero, transform.position);

		if(distance < 2.0f){
			GameObject.FindWithTag("GameManager").GetComponent<GameManager>().AddDamage(1);
			Destroy(gameObject);
		}
	}

	private bool mIsDeadProcess;
}

