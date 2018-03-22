using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBuilding : MonoBehaviour {
	public bool playerInBuilding = false;

	public void setPlayerInBuilding(bool b){
		playerInBuilding = b;
	}

    public bool getPlayerInBuilding(){
        return playerInBuilding;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
