using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Personality {
	/**
	 * Scale according to skills 
	 */

	/*
	// What increases/decreases happiness
	/// Excess food
	float gluttony;
	/// Excess gold
	float greed;
	/// Happy when they are doing the least.
	float sloth;
	/// Gets upset when damaged.
	float wrath;
	/// Can't have people above them
	float envy;
	/// Doing the best.
	float pride;
	/// Wants a certain number of people
	float lust;
	*/
	/*

	*/

	//public enum traitList{gluttony, greed, sloth, wrath, envy, pride, lust};

	// liklihood out of 100
	public enum PersonalityTrait{
		COWARD = 8, 
		STRONG = 8, 
		OPTIMIST = 10, 
		ANGRY = 8, 
		BRAVE = 10, 
		GREEDY = 9, 
		GATHERER = 10, 
		CHEF = 10, 
		CHARISMA = 10, 
		LAZY = 8, 
		MURDERER = 1
	};


	public static int sizeTraitList = Enum.GetNames(typeof(PersonalityTrait)).Length;
	private float rank;
	private int probSize;

	TraitDict<PersonalityTrait,float> personVal;

	public Personality(){
		personVal = new TraitDict<PersonalityTrait, float> (sizeTraitList, 0f);

		int probSize = 0;
		foreach (PersonalityTrait p in Enum.GetValues(typeof(PersonalityTrait))) {
			probSize += (int)p;
		}

		// Currently set to randomly generate for each
		foreach (PersonalityTrait p in Enum.GetValues(typeof(PersonalityTrait))) {
			float rand = UnityEngine.Random.Range (0, 100);
			if (rand <= (float)p) {
				personVal.setValue(p, rand / (float)p);
			}
		}


	}

	private void setRank(){
		rank = 0f;
		foreach(KeyValuePair<PersonalityTrait,float> i in personVal.getDict()){
			//weaknesses affect rank less than strengths
			if (i.Value < 0)
				rank += i.Value / 2;
			else
				rank += i.Value;
		}
	}

	public float getRank(){
		return rank;
	}

	public float getValue(PersonalityTrait t){
		return personVal.getValue (t);
	}

}
