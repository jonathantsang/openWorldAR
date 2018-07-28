using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour{
	// Normal Movements Variables
	private float walkSpeed;
	private float curSpeed;
	private float maxSpeed;
	private Rigidbody2D rb2d;

	void Start()
	{
		walkSpeed = 6;
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		curSpeed = walkSpeed;
		maxSpeed = curSpeed;

		// Move sentences
		rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* curSpeed, 0.8f),
			Mathf.Lerp(0, Input.GetAxis("Vertical")* curSpeed, 0.8f));
	}
}