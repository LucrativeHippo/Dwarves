using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actor : MonoBehaviour {

	private bool actionable;
	public KeyCode actionKey;
	private GameObject collidedGameObject;
	private bool canSend;

	void Start() {
		canSend = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		actionable = true;
		collidedGameObject = other.gameObject;
		Debug.Log ("actionable = true");
	}

	void OnTriggerExit2D(Collider2D other) {
		actionable = false;
		Debug.Log ("actionable = false");
	}

	void FixedUpdate() {
		if(Input.GetKey(actionKey) && actionable && canSend) {
			Debug.Log ("action Logged.");
			canSend = false;
			SendMessage ();
		}
	}

	void SendMessage() {
		collidedGameObject.SendMessage ("recieveMessage");
		canSend = true;
	}
}
