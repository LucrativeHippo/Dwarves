using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_stats : MonoBehaviour {


	public Attributes a;
	[SerializeField]
	private float max_health;
	[SerializeField]
	private float cur_health;
	[SerializeField]
	private int damage;
	[SerializeField]
	private float atkSpeed;
	// Use this for initialization
	void Awake () {
		getstats ();

		}
		
	

	// Update is called once per frame
	void Update () {
		
	}
	void getstats(){
		a =gameObject.GetComponent<Attributes> ();
		damage = a.strength;
				switch (a.level) {
				case 1:
					max_health = 30f;
					cur_health = 30f;
					atkSpeed = 1f;;
					break;
				case 2:
					max_health = 50f;
					cur_health = 50f;
					atkSpeed = 1.5f;
					break;
				case 3:
					max_health = 100f;
					cur_health = 100f;
					atkSpeed = 2.0f;
					break;
}
}
}
