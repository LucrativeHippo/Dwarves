using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_basicStats : MonoBehaviour {

	public GameObject npc;

	private Attributes stats;


	private float max_health;

	private float cur_health;
	private float damage;
	private float atkSpeed;
	void Start(){
		stats = npc.GetComponent<Attributes> ();
	}



//	// Use this for initialization
//	void Start () {
//		stats = npc.GetComponent<Attributes> ();
//		switch (stats.level) {
//		case 1:
//			max_health = 30f;
//			cur_health = 30f;
//			atkSpeed = 1f;
//			damage = 3f;
//			break;
//		case 2:
//			max_health = 50f;
//			cur_health = 50f;
//			atkSpeed = 1.5f;
//			damage = 5f;
//			break;
//		case 3:
//			max_health = 100f;
//			cur_health = 100f;
//			atkSpeed = 2.0f;
//			damage = 10f;
//			break;
//		}
//}
//	
//	// Update is called once per frame
//	void Update () {
//			
//	}
}
