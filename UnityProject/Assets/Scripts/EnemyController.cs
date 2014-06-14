using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public float Speed = 1.0f;
	public float attackpower = 1.0f;
	public float enemyhealth = 1.0f;

	public bool IsDead() { return enemyhealth <= 0.0f; }

	public void AddDamage(float iDamage)
	{
		if (IsDead()) { return; }

		enemyhealth -= iDamage;
		if (enemyhealth < 0.0f) { enemyhealth = 0.0f; }

		if (IsDead()) { StartCoroutine(DeadProcess()); }
	}

	private IEnumerator DeadProcess()
	{
		if (!IsDead()) { yield break; }
		mIsDeadProcess = true;


		Destroy(gameObject);
	}


	void FixedUpdate()
	{
		if (IsDead()) { return; }

		transform.LookAt(Vector3.zero);

		Vector3 aPosition = Vector3.zero - rigidbody.position;

		rigidbody.position = rigidbody.position + (aPosition.normalized * Speed * Time.fixedDeltaTime);

	}
	private void OnTriggerEnter(){
		Destroy(gameObject);

	}

	private bool mIsDeadProcess;
}

