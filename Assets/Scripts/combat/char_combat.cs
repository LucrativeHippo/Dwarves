using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class char_combat : MonoBehaviour {
	public Attributes npcStats;
	enemyAI enemyStats;
	bool isEnemy = false;
	bool isNPC = false;
	bool isPlayer = false;
	public bool inCombat = false;
	public GameObject opponent;
	public int opponentDamage;
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
		if (inCombat && isEnemy ) {
			combat ();
			enemyStats.cur_health -= opponentDamage * Time.deltaTime;
			timestamp = Time.time + 1.0f;
		}
		if (inCombat && isNPC ) {
			combat ();
			npcStats.cur_health -= opponentDamage* Time.deltaTime;
			timestamp = Time.time + 1.0f;
		}
	}
	void getOpponent(){
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("y");
		if ((gameObject.tag == "OwnedNPC" && other.tag == "Enemy") ||
		    (gameObject.tag == "Enemy" && other.tag == "OwnedNPC") ||
		    (gameObject.tag == "Player" && other.tag == "Enemy") ||
		    (gameObject.tag == "Enemy" && other.tag == "Player")) {
			inCombat = true;
			opponent = other.gameObject;
		} else {
			inCombat = false;
		}
		}
		
	void combat(){
		if (isNPC == true) {
			enemyStats=opponent.GetComponent<enemyAI> ();
			Debug.Log (enemyStats);
			opponentDamage = enemyStats.damage;
		}
		if (isEnemy == true && opponent.tag == "OwnedNPC") {
			npcStats=opponent.GetComponent<Attributes> ();
			opponentDamage = npcStats.damage;
		}
		if (isEnemy == true && opponent.tag == "Player") {
			//TODO:
			//NO PLAYER STATS YET
		}
	}

}
