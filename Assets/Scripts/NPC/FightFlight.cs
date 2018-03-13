using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightFlight : MonoBehaviour {
	public void gotHit(){

		// If a guard they should path to the enemy on their own

		//non guards will have to decide what to do
		if(!GetComponent<Guard>().enabled){
			//StateSwitch
		}
	}
}
