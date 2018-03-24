using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBell : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		if(Input.GetKeyDown(KeyCode.Q)){
			ring();
		}
	}

	public bool danger = false;
	private void ring(){
		danger = !danger;
		foreach(GameObject g in GetComponent<OwnedNPCList>().getNPCs()){
			g.GetComponent<IBellListener>().forceBell(danger);
		}
	}
}
