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
		Vector3 aPosition = Vector3.zero - rigidbody.position;

		rigidbody.position = rigidbody.position + (aPosition.normalized * Speed * Time.fixedDeltaTime);

	}
}
