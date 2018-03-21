﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FightFlight : MonoBehaviour, IHealthListener, IBellListener {
	private enum state {
		COLLECT, GUARD, FOLLOW, FLEE, UNSET
	}
	[SerializeField]
	state prevState = state.UNSET;
	state curState = state.UNSET;
	public void gotHit(){

		// If a guard they should path to the enemy on their own

		//non guards will have to decide what to do
		if(!GetComponent<Guard>().enabled){
			convert();

			// Choose Fight or Flight
			if(curState != state.FLEE && isBrave()){
				curState = state.GUARD;
				GetComponent<Guard>().enabled = true;
			}else{
				curState = state.FLEE;
				flight();
			}

		}else{
			if(prevState == state.UNSET){
				prevState = state.GUARD;
			}
		}
	}

	private bool isBrave(){	return GetComponent<Skills>().getValue(Skills.list.braveness)>5; }

	private void convert(){
		if(GetComponent<collect>().enabled){
			prevState = state.COLLECT;
			GetComponent<collect>().enabled = false;

		}else if(GetComponent<follow>().enabled){
			prevState = state.FOLLOW;
			GetComponent<follow>().enabled = false;
		}
	}

	public void revert(){
		if(prevState != state.GUARD){
			GetComponent<Guard>().enabled = false;
			switch(prevState){
				case state.COLLECT:
					GetComponent<collect>().enabled = true;
					break;
				case state.FOLLOW:
					GetComponent<follow>().enabled = true;
					break;
			}
		}
		prevState = state.UNSET;
		curState = state.UNSET;
	}

	public void flight(){
		if(prevState == state.UNSET){
			prevState = state.FLEE;
		}
		GameObject safety = collect.findClosestTag("Shelter",gameObject);
		if(safety != null){
			GetComponent<NavMeshAgent>().SetDestination(safety.transform.position);
		}else{
			Debug.Log("NPC couldn't find a nearby shelter, and is now frozen in terror");
		}
	}

	private Health npcHealth;
    public void setHealth(Health health)
    {
		npcHealth = health;
		health.addSubscriber(this);
    }

    public void publish()
    {
		float percentage = 100 * (float)npcHealth.getHealth() / (float)npcHealth.getMaxHealth();
		if(percentage<=20){
			convert();
			flight();
		}
    }

    public void bellRang(bool safe)
    {
		if(!safe){
			gotHit();
		}else{
			revert();
		}
    }
}