using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Skills {
	/// All job based skills available to the NPCs
	/// Adapts regardless of size
	public enum skillList{wood, stone, gold, food};

	public static int skillNPCSize = Enum.GetNames(typeof(skillList)).Length;

	// npc skill level (translates to its cost)
	// bool if it's recruited
	// 

	/// Gathering multiplier [0.5,1.5]
	float gatherSpeed = 1.0f;

	// TODO: Maybe better to have these in their own script
	// it can then be attached to creatures without skills
	float attackDMG = 1.0f;
	float attackSPD = 1.0f;

	Dictionary<skillList,float> skillMultiplier;

	public Skills(bool random){
		skillMultiplier = new Dictionary<skillList,float> (skillNPCSize);
		if(random){
			randomizeSkills (UnityEngine.Random.Range(0,skillNPCSize));
		}
	}

	private void randomizeSkills(int numOfSkills){
		for (int i = 0; i < numOfSkills; i++) {
			float rand;
			float randSkill;

			do {
				randSkill = UnityEngine.Random.Range(0,skillNPCSize);
				rand = UnityEngine.Random.value;
			} while(skillMultiplier.ContainsKey ((skillList)randSkill));
			//linear spread
			skillMultiplier [(skillList)randSkill] = rand + 0.5f;
		}
	}

	public float getSkillVal(skillList s){
		if (skillMultiplier.ContainsKey (s))
			return skillMultiplier [s];
		else
			return 1f;
	}

	public void setSkillVal(skillList s, float newVal){
		skillMultiplier [s] = newVal;
	}


}
