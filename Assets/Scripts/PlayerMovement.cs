using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	void FixedUpdate() {
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector2.up * speed);
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate (Vector2.left * speed);
		}
		if (Input.GetKey(KeyCode.S)){
			transform.Translate (Vector2.down * speed);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate (Vector2.right * speed);
		}
	}
}
