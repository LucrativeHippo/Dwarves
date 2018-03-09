using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
    void FixedUpdate() {
		Vector3 mov = new Vector3 (0, 0);

		mov += Input.GetKey (KeyCode.W) ? Vector3.forward : Vector3.zero;
		mov += Input.GetKey (KeyCode.S) ? Vector3.back : Vector3.zero;

		mov += Input.GetKey (KeyCode.A) ? Vector3.left : Vector3.zero;
		mov += Input.GetKey (KeyCode.D) ? Vector3.right : Vector3.zero;

		mov.Normalize ();

		transform.Translate (mov * speed);

        GetComponentInChildren<actionManagerPlayerRotation>().setRotation(mov);
    }
}
