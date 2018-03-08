using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class char_combat : MonoBehaviour {
	public Attributes npcStats;
	enemyAI enemyStats;
	bool isEnemy = false;
	bool isNPC = false;
	bool isPlayer = false;
	bool timeControl = true;
	public bool inCombat = false;
	public GameObject opponent;
	public float opponentDamage;
	public float opponentCoolDown = 1.0f;
	private float timestamp = 0.0f;

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "OwnedNPC") {
			npcStats = GetComponent<Attributes>();
			isNPC = true;
		}
		if (gameObject.tag == "Enemy") {
			enemyStats = GetComponent<enemyAI> ();
			isEnemy = true;
		}
		//TODO: NO PLAYER STATS YET
	}

	// Update is called once per frame
	void Update () {
		if (inCombat && timeControl)
			StartCoroutine(combatManager());
			
	}

	//Manage the combat damage
	IEnumerator combatManager() {
		timeControl = false;
		if (inCombat && isEnemy ) {
			combat ();
			enemyStats.cur_health -= opponentDamage;
			Debug.Log ("npc" + opponentCoolDown);
			yield return new WaitForSeconds (opponentCoolDown);
			timeControl = true;
			//UNCOMMENT this one if you want hp to drop smoothly
//			enemyStats.cur_health -= opponentDamage * Time.deltaTime;
//			timestamp = Time.time + 1.0f;
		}
		else if (inCombat && isNPC ) {
			combat ();
			npcStats.cur_health -= opponentDamage;
			yield return new WaitForSeconds (opponentCoolDown);
			timeControl = true;
			////UNCOMMENT this one if you want hp to drop smoothly
//			npcStats.cur_health -= opponentDamage* Time.deltaTime;
//			timestamp = Time.time + 1.0f;
		}
//		if (isEnemy) {
//			yield return new WaitForSeconds (opponentCoolDown);
//		}
//		if (isNPC) {
//			yield return new WaitForSeconds (opponentCoolDown);
//		}
//		 

	}
	void OnTriggerEnter(Collider other) {
		timeControl = true;
		Debug.Log ("y");
		if ((gameObject.tag == "OwnedNPC" && other.tag == "Enemy") ||
		    (gameObject.tag == "Enemy" && other.tag == "OwnedNPC") ||
		    (gameObject.tag == "Player" && other.tag == "Enemy") ||
		    (gameObject.tag == "Enemy" && other.tag == "Player")) {
			inCombat = true;
			opponent = other.gameObject;
		} 

		}
		
	void OnTriggerExit(Collider other) {
			inCombat = false;
		opponentCoolDown = 0.0f;
	}


	void combat(){
		if (isNPC == true) {
			enemyStats=opponent.GetComponent<enemyAI> ();
			Debug.Log (enemyStats);
			opponentDamage = enemyStats.damage;
			opponentCoolDown = 2.0f/enemyStats.atkSpeed;

		}
		if (isEnemy == true && opponent.tag == "OwnedNPC") {
			npcStats=opponent.GetComponent<Attributes> ();
			opponentDamage = npcStats.damage;
			opponentCoolDown = 2.0f/npcStats.atkSpeed;
		}
		if (isEnemy == true && opponent.tag == "Player") {
			//TODO:
			//NO PLAYER STATS YET
		}
	}

}
