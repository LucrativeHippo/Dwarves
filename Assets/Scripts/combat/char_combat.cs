using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class char_combat : MonoBehaviour {
	//public Attributes npcStats;
	//enemyAI enemyStats;
	bool isEnemy = false;
	bool timeControl = true;
	public bool inCombat = false;
	public GameObject opponent;
	//public float opponentDamage;
	public float coolDown = 1.0f;
	private float timestamp = 0.0f;

	// Use this for initialization
	void Start () {
		isEnemy = gameObject.tag == "Enemy";
	}

	// Update is called once per frame
	void Update () {
		if (inCombat && timeControl)
			StartCoroutine(combatManager());
			
	}

	//Manage the combat damage
	IEnumerator combatManager() {
		timeControl = false;
		if (inCombat) {
			combat ();
			yield return new WaitForSeconds (coolDown);
			timeControl = true;
			//UNCOMMENT this one if you want hp to drop smoothly
//			enemyStats.cur_health -= opponentDamage * Time.deltaTime;
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

	private bool isEnemyTag(Collider other){
		char_combat temp = other.gameObject.GetComponent<char_combat>();
		return temp != null && isEnemy != temp.isEnemy;
	}

	private bool checkLocal = false;
	public void addTarget(Collider other){
		if(isEnemyTag(other)){
			timeControl = true;
			opponent = other.gameObject;
			inCombat = true;
		} 
	}
	void OnTriggerEnter(Collider other) {
		if(!inCombat)
			addTarget(other);
	}
	// TODO: Change checkLocal to true once opponent is gone


	void OnTriggerStay(Collider other){
		if(checkLocal){
			addTarget(other);
			checkLocal = false;
		}
	}
		
	void OnTriggerExit(Collider other) {
		
	}


	void combat(){
		Debug.Log("Combat Entered");
		if(opponent != null){
			opponent.GetComponent<Health>().damage(1);

		}
		// if (isNPC == true) {
		// 	enemyStats=opponent.GetComponent<enemyAI> ();
		// 	Debug.Log (enemyStats);
		// 	opponentHealth.damage(1);
		// 	//opponentDamage = enemyStats.damage;
		// 	opponentCoolDown = 2.0f/enemyStats.atkSpeed;

		// }
		// if (isEnemy == true && opponent.tag == "OwnedNPC") {
		// 	//npcStats=opponent.GetComponent<Attributes> ();
		// 	opponentHealth.damage(1);
		// 	//opponentDamage = npcStats.damage;
		// 	//opponentCoolDown = 2.0f/npcStats.atkSpeed;
		// }
		// if (isEnemy == true && opponent.tag == "Player") {
		// 	//TODO:
		// 	//NO PLAYER STATS YET
		// }
	}

}
