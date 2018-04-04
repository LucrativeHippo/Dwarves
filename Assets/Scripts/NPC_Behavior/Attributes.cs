using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attributes : MonoBehaviour {
		//player basic stats
		public int braveness;
		public int strength;
		public int charisma;
		public int motivation;
		public int skill;
		//float level; // current level
		//float exp_to_level;//exp needed to level up
	public int level;
		
	private int totalLevel1 = 15;
	private int totalLevel2 = 25;
	private int totalLevel3 = 35;

	[SerializeField]
	public float cur_health;
	[SerializeField]
	public float damage;
	[SerializeField]
	public float atkSpeed;



		
	// randomly generate an array of 5 integers of stats for npc
	public int[] statGenerator(int level){
		int count = 5;
		int sum;
		int[] a = new int[count];
		switch (level) 
		{
		case 1:
			sum = totalLevel1;
			a = new int[count];
			sum -= count;

			for (int i = 0; i < count; i++) {
				a [i] = UnityEngine.Random.Range (0, count + 1);
			}
			a [count - 1] = sum;
			Array.Sort (a);
			for (int i = count - 1; i > 0; i--) {
				a [i] -= a [i - 1];
			}
			for (int i = 0; i < count; i++) {
				a [i]++;
			}
			for (int i = 0; i < count; i++) {
				while (a [i] >= 7) {
					a [i] -= 5;
					for (int j = 0; j < count; j++) {
						a [j] += 1;
					}
				}
			}
		
//			braveness = a [0];
//			strength = a [1];
//			charisma = a [2];
//			motivation = a [3];
//			skill = a [4];
			break;

		case 2:
			sum = totalLevel2;
			a = new int[count];
			sum -= count;

			for (int i = 0; i < count; i++) {
				a [i] = UnityEngine.Random.Range (0, count + 1);
			}
			a [count - 1] = sum;
			Array.Sort (a);
			for (int i = count - 1; i > 0; i--) {
				a [i] -= a [i - 1];
			}
			for (int i = 0; i < count; i++) {
				a [i]++;
			}
			for (int i = 0; i < count; i++) {
				while (a [i] > 10 ) {
					if (i > 0) {
						a [i - 1] += a [i] / 2;
						a [i] = a [i] / 2;
					}
					if (i == 0) {
						a [i + 1] += a [i] / 2;
						a [i] = a [i] / 2;
					}
				}
			}
			for (int i = 0; i < count; i++) {
				while (a [i] > 10 ) {
					if (i > 0) {
						a [i - 1] += a [i] / 2;
						a [i] = a [i] / 2;
					}
					if (i == 0) {
						a [i + 1] += a [i] / 2;
						a [i] = a [i] / 2;
					}
				}
			}
			for (int i = 0; i < count; i++) {
				while (a [i] > 10 ) {
					if (i > 0) {
						a [i - 1] += a [i] / 2;
						a [i] = a [i] / 2;
					}
					if (i == 0) {
						a [i + 1] += a [i] / 2;
						a [i] = a [i] / 2;
					}
				}
			}

		
//			braveness = a [0];
//			strength = a [1];
//			charisma = a [2];
//			motivation = a [3];
//			skill = a [4];
			break;
		case 3:
			sum = totalLevel3;
			a = new int[count];
			sum -= count;

			for (int i = 0; i < count; i++) {
				a [i] = UnityEngine.Random.Range (0, count + 1);
			}
			a [count - 1] = sum;
			Array.Sort (a);
			for (int i = count - 1; i > 0; i--) {
				a [i] -= a [i - 1];
			}
			for (int i = 0; i < count; i++) {
				a [i]++;
			}
			for (int i = 0; i < count; i++) {
				while (a [i] > 10) {
					a [i] -= 10;
					for (int j = 0; j < count; j++) {
						a [j] += 2;
					}
				}
			}
			for (int i = 0; i < count; i++) {
				while (a [i] > 10) {
					a [i] -= 5;
					for (int j = 0; j < count; j++) {
						a [j] += 1;
					}
				}
			}
		

//			braveness = a [0];
//			strength = a [1];
//			charisma = a [2];
//			motivation = a [3];
//			skill = a [4];
			break;
			
	}
		return a;
	}



	void Awake(){
		//statGenerator (1);
		//statGenerator (2);
		int[] a = statGenerator (level);
		shuffle (a);
		this.assignStats (a);
		damage = strength;
		//print all stats of npc
		Debug.Log ("level: "+level+" braveness: " + a [0]  + " strength: " + a [1]  + " charisma: " + a [2]
			+ " motivation: " + a [3]   + " skill: " + a [4]); 
		switch (level) {
		case 1:
			cur_health = 30f;
			atkSpeed = 1f;;
			break;
		case 2:
			cur_health = 50f;
			atkSpeed = 1.5f;
			break;
		case 3:
			cur_health = 100f;
			atkSpeed = 2.0f;
			break;
		}
		
	}
	
	void assignStats(int[] a){
				braveness = a[0];
				strength = a[1];
				charisma = a[2];
				motivation = a[3];
				skill = a[4];
			}

	//shuffle the number so the generated stats will be more randomized
	public static void shuffle<T>(T[] array)
	{
		System.Random rand = new System.Random();
		for (int i = array.Length; i > 1; i--)
		{
			// Pick random element to swap.
			int j = rand.Next(i); // 0 <= j <= i-1
			// Swap.
			T tmp = array[j];
			array[j] = array[i - 1];
			array[i - 1] = tmp;
		}
	}

	void Update(){
		if (cur_health <= 0)
			die ();
	}

	void die(){
		Destroy (gameObject);
	}

		

}


