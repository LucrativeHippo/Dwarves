using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Skills : Character {
    /// All job based skills available to the NPCs
    /// Add skills 
    public enum list {
        braveness,
        strength,
        charisma,
        motivation,
        skill
    };

    public static int numOfSkills = Enum.GetNames (typeof(list)).Length;

    // npc skill level (translates to its cost)
    // bool if it's recruited
    //

    /// Gathering multiplier [0.5,1.5]
    public float gatherSpeed = 1.0f;

    [ReadOnly] public float rank = 0f;
    //private float maxSize = 10;

    [NamedArray(typeof(list))] public float[] skillLevel = new float[numOfSkills];

    public bool customNPC = false;
    public void Awake () {
        if(!customNPC){
            randomizeSkills ();
        }
        setRank();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="poolSize">Value from 0</param>
    private void setSkillsByPool(int poolSize){
        for(int i=0;i<numOfSkills;i++){
            skillLevel[i] = 0;
        }
        
        for(int i=0;i<poolSize&&i<numOfSkills*10;i++){
            int rand = UnityEngine.Random.Range(0,numOfSkills);
            if(skillLevel[rand] != 10)
                skillLevel[rand]++;
        }
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
    public static float rollSkill(){
        float rand = 0;
        for(int i=0;i<5;i++){
            rand += UnityEngine.Random.Range(0f,2f);
        }
        return Mathf.Round(rand);
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
    public int getIntRank(){
        setRank();
        return Mathf.RoundToInt(rank);
    }

    /// <summary>
    /// Get value of Skill
    /// </summary>
    /// <param name="s">Skill to be viewed</param>
    /// <returns>0->10 value</returns>
    public float getValue (list s) {
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

    void OnValidate() {
        setRank();
    }
}
