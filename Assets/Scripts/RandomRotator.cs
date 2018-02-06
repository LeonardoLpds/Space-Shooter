using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
	private Rigidbody body;
	public float tumble;

	void Start ()
	{
		body = GetComponent<Rigidbody> ();
		body.angularVelocity = Random.insideUnitSphere * tumble;
	}	
}
