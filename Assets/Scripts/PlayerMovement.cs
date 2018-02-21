using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	void FixedUpdate() {
		Vector2 mov = new Vector2 (0, 0);

		mov += Input.GetKey (KeyCode.W) ? Vector2.up : Vector2.zero;
		mov += Input.GetKey (KeyCode.S) ? Vector2.down : Vector2.zero;

		mov += Input.GetKey (KeyCode.A) ? Vector2.left : Vector2.zero;
		mov += Input.GetKey (KeyCode.D) ? Vector2.right : Vector2.zero;

		mov.Normalize ();

		transform.Translate (mov * speed);
	}
}
