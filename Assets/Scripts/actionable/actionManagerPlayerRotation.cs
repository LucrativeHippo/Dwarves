using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionManagerPlayerRotation : MonoBehaviour {

	public Transform player;
	public float radious = 1f;

	private Vector3 actionboxDirection = new Vector3(0, 10);

	void Start() {
		player = transform.parent.transform;
	}

	void FixedUpdate() {
//		Vector3 actionboxToMouse = Camera.main.ScreenToWorldPoint (Input.mousePosition) - player.position;
		if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
			rotateTopLeft ();
		}
		else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) {
			rotateTopRight ();
		}
		else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) {
			rotateBottomLeft ();
		}
		else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
			rotateBottomRight ();
		}
		else if (Input.GetKey(KeyCode.W)) {
			rotateTop ();
		}
		else if (Input.GetKey(KeyCode.A)) {
			rotateLeft ();
		}
		else if (Input.GetKey(KeyCode.S)){
			rotateDown ();
		}
		else if(Input.GetKey(KeyCode.D)){
			rotateRight ();
		}

		actionboxDirection.z = 0;
		transform.position = player.position + (radious * actionboxDirection.normalized);
	}

	private void rotateTop() {
		actionboxDirection = new Vector3(0, radious);
	}

	private void rotateLeft() {
		actionboxDirection = new Vector3(-radious, 0);
	}

	private void rotateDown() {
		actionboxDirection = new Vector3(0, -radious);
	}

	private void rotateRight() {
		actionboxDirection = new Vector3(radious, 0);
	}

	private void rotateTopLeft() {
		actionboxDirection = new Vector3(-radious, radious);
	}

	private void rotateTopRight() {
		actionboxDirection = new Vector3(radious, radious);
	}

	private void rotateBottomRight() {
		actionboxDirection = new Vector3(radious, -radious);
	}

	private void rotateBottomLeft() {
		actionboxDirection = new Vector3(-radious, -radious);
	}

}
