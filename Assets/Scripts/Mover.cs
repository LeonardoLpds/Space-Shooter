using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	private Rigidbody body;
	public float speed;

	void Start ()
	{
		body = GetComponent<Rigidbody>();
		body.velocity = transform.forward * speed;
	}
}
