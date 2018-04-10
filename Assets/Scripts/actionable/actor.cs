using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actor : MonoBehaviour {

	private bool actionable;
	public KeyCode actionKey;
	private bool canSend = true;
    private bool canSendNextFrame = true;

    private float timeSinceAction;
	public float actionCooldownSec = 0.8f;

	private Controls controls;
	void Start(){
        timeSinceAction = 0;
		controls = MetaScript.GetControls();
	}

    private void Update()
    {
        if (!canSendNextFrame)
        {
            canSend = false;
        }
        if (!canSend)
        {
            timeSinceAction += Time.deltaTime;
            if (timeSinceAction >= actionCooldownSec)
            {
                canSend = true;
                canSendNextFrame = true;
                timeSinceAction = 0;
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if (controls.key(controls.Action) && canSend)
        {
            canSendNextFrame = false;
            other.gameObject.SendMessage("recieveAction");
        }
		
	}

	void OnTriggerExit(Collider other) {
	}


	void SendMessage() {
		canSend = true;
	}
}
