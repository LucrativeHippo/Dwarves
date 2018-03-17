using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightFlight : MonoBehaviour {
	private enum state {
		COLLECT, GUARD, FOLLOW, UNSET
	}
	state prevState = state.UNSET;
	public void gotHit(){

		// If a guard they should path to the enemy on their own

		//non guards will have to decide what to do
		if(!GetComponent<Guard>().enabled){
			if(GetComponent<collect>().enabled){
				prevState = state.COLLECT;
				GetComponent<collect>().enabled = false;

			}else if(GetComponent<follow>().enabled){
				prevState = state.FOLLOW;
				GetComponent<follow>().enabled = false;
			}
			GetComponent<Guard>().enabled = true;
		}else{
			if(prevState != state.GUARD){
				prevState = state.GUARD;
			}
		}
	}
	public void revert(){
		if(prevState != state.GUARD){
			GetComponent<Guard>().enabled = false;
			if(prevState == state.COLLECT){
				GetComponent<collect>().enabled = true;
			}else if(prevState == state.FOLLOW){
				GetComponent<follow>().enabled = true;
			}
			prevState = state.UNSET;
		}
		
	}
}
