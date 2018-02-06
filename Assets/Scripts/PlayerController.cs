using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

[System.Serializable]
public class Boundery
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	private Rigidbody body;
	public float speed;
	public float tilt;
	public Boundery boundery;

	public GameObject shot;
	public Transform shotSpawn;
	private float myTime = 0.0F;
	private float nextFire = 0.5F;
	public float fireDelta = 0.25F;

	void Start ()
	{
		body = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton("Fire1") && myTime > nextFire)
		{
			nextFire = myTime + fireDelta;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical   = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		body.velocity = movement * speed;

		body.position = new Vector3 (
			Mathf.Clamp(body.position.x, boundery.xMin, boundery.xMax),
			0.0f,
			Mathf.Clamp(body.position.z, boundery.zMin, boundery.zMax)
		);

		body.rotation = Quaternion.Euler (0.0f, 0.0f, body.velocity.x * -tilt);
	}
}