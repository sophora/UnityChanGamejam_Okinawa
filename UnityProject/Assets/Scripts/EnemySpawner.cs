using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	public GameObject Enemy_001;

	// Use this for initialization
	void Start ()
	{
		//Instantiate(Enemy_001, , Quaternion.identity);

	}
	private float second;
	// Update is called once per frame
	void Update ()
	{
		second += Time.deltaTime ;
		if(second > 5.0f){
		float rat = Random.Range(0.0f,360.0f);   
		float x = 40.0f * Mathf.Cos(Mathf.PI * rat / 180.0f);
		float z = 40.0f* Mathf.Sin(Mathf.PI * rat / 180.0f);
			
		Instantiate ( Enemy_001, new Vector3(x,3,z),Quaternion.identity );
	    second = 0.0f; 
		} 

	}
}
