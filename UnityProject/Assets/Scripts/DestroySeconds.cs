using UnityEngine;
using System.Collections;

public class DestroySeconds : MonoBehaviour
{
	public float Seconds;

	private void Start ()
	{
		Destroy(gameObject, Seconds);
	}
}
