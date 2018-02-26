using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actor : MonoBehaviour {

	private bool actionable;
	public KeyCode actionKey;
	private GameObject collidedGameObject;
	private bool canSend = true;

	public int actionCooldownSec = 5;

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
			SendMessage ();
			StartCoroutine( canSendTimer() );
		}
	}

	void SendMessage() {
		collidedGameObject.SendMessage ("recieveAction");
		canSend = true;
	}

	IEnumerator canSendTimer() {
		canSend = false;

		for(int i=0; i< actionCooldownSec; i++) {
			yield return new WaitForSeconds(1.0f);
		}

		canSend=true;
	}
}
