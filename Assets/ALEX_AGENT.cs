using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALEX_AGENT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	bool agent = false;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.CapsLock)){
			if(agent){
				GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
			}
			agent = !agent;
		}
		if(agent){
			GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
		}

		if(Input.GetKeyDown(KeyCode.Slash)){
			MetaScript.getPlayer().GetComponent<Health>().death();
		}
	}
}
