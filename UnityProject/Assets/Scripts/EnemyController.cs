using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public float Speed = 1.0f;

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate()
	{
		transform.LookAt(Vector3.zero);

		Vector3 aPosition = Vector3.zero - rigidbody.position;

		rigidbody.position = rigidbody.position + (aPosition.normalized * Speed * Time.fixedDeltaTime);

		if(enemyhealth == 0){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other){

		Destroy(gameObject);
	}
	public float attackpower = 1.0f;
	public float enemyhealth = 1.0f;

	void OntrriggerEnter(Collider other){
		AttackBase aAttack = other.gameObject.GetComponent<AttackBase>();
		if(aAttack !=null){
			enemyhealth = enemyhealth - aAttack.Damage;

		}
		
	}



}

