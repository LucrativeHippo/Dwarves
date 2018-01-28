using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private Rigidbody2D playerRigidbody2d;

	void Start() {
		playerRigidbody2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		playerRigidbody2d.AddForce (movement * speed);
	}
}
