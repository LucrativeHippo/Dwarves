using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actor : MonoBehaviour {

	private bool actionable;
	public KeyCode actionKey;
	private bool canSend = true;

	public int actionCooldownSec = 5;

	private Controls controls;
	void Start(){
		controls = MetaScript.GetControls();
	}

	void OnTriggerStay(Collider other) {
        if (controls.keyDown(controls.Action) && canSend)
        {
            canSend = false;
            other.gameObject.SendMessage("recieveAction");
            StartCoroutine(canSendTimer());
        }
		
	}

	void OnTriggerExit(Collider other) {
	}


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
