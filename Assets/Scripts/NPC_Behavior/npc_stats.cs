using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_stats : MonoBehaviour {


	public Attributes a;
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
					atkSpeed = 1f;;
					break;
				case 2:
					atkSpeed = 1.5f;
					break;
				case 3:
					atkSpeed = 2.0f;
					break;
}
}
}
