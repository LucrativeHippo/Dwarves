using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actor : MonoBehaviour {

	private bool actionable;
	public KeyCode actionKey;
	private bool canSend = true;

	public int actionCooldownSec = 5;

	void OnTriggerStay(Collider other) {
        if (Input.GetKey(actionKey) && canSend)
        {
            canSend = false;
            other.gameObject.SendMessage("recieveAction");
            StartCoroutine(canSendTimer());
        }
		
	}

	void OnTriggerExit(Collider other) {
	}

	/*void FixedUpdate() {
		if(Input.GetKey(actionKey) && actionable && canSend) {
			Debug.Log ("action Logged.");
			SendMessage ();
			StartCoroutine( canSendTimer() );
		}
	}*/

	void SendMessage() {
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
