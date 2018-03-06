using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Skills : MonoBehaviour {
    /// All job based skills available to the NPCs
    /// Add skills 
    public enum skillList {
        wood,
        stone,
        gold,
        food,
        diamond
    };

    public static int numOfSkills = Enum.GetNames (typeof(skillList)).Length;

    // npc skill level (translates to its cost)
    // bool if it's recruited
    //

    /// Gathering multiplier [0.5,1.5]
    public float gatherSpeed = 1.0f;

    public float rank = 0f;
    //private float maxSize = 10;

    [NamedArray(typeof(skillList))] public float[] skillLevel = new float[numOfSkills];

    public void Start () {
        randomizeSkills ();
        setRank();
    }

    private void randomizeSkills () {
        // float skillPool = numOfSkills * maxSize;
        
        for (int i = 0; i < numOfSkills; i++) {
            skillLevel[i] = rollSkill();
        }
    }

    /// <summary>
    /// Rolls 5 values from [0f,2f] adds up to value from [0f,10f]
    /// </summary>
    /// <returns></returns>
    private float rollSkill(){
        float rand = 0;
        for(int i=0;i<5;i++){
            rand += UnityEngine.Random.Range(0f,2f);
        }
        return rand;
    }

    private void setRank(){
        rank = 0f;
        for (int i=0;i<numOfSkills;i++) {
            rank += Mathf.Pow(skillLevel[i],3);
        }
        rank /= numOfSkills*2;
    }

    /// <summary>
    /// Rank of NPC, used for quests.
    /// </summary>
    /// <returns></returns>
    public float getRank(){
        setRank();
        return rank;
    }

    /// <summary>
    /// Get value of Skill
    /// </summary>
    /// <param name="s">Skill to be viewed</param>
    /// <returns>0->10 value</returns>
    public float getValue (skillList s) {
        return getValue((int)s);
    }
    /// <summary>
    /// Get value of skill
    /// </summary>
    /// <param name="i">Index value of skill</param>
    /// <returns>Value of skill at i</returns>
    public float getValue(int i){
        return skillLevel[i];
    }
}
