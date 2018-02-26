using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Personality : MonoBehaviour {
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
    public enum Trait {
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
        MURDERER = 1}

    ;


    public static int sizeTraitList = Enum.GetNames (typeof(Trait)).Length;
    private float rank;
    private int probSize;

    TraitDict<Trait,float> personVal;

    public void Start () {
        // TODO: Maybe change this
        personVal = new TraitDict<Trait, float> (sizeTraitList, 0f);

        int probSize = 0;
        foreach (Trait p in Enum.GetValues(typeof(Trait))) {
            probSize += (int)p;
        }

        // Currently set to randomly generate for each
        foreach (Trait p in Enum.GetValues(typeof(Trait))) {
            float rand = UnityEngine.Random.Range (0, 100);
            if (rand <= (float)p) {
                personVal.setValue (p, rand / (float)p);
            }
        }


    }

    private void setRank () {
        rank = 0f;
        foreach (KeyValuePair<Trait,float> i in personVal.getDict()) {
            //weaknesses affect rank less than strengths
            if (i.Value < 0)
                rank += i.Value / 2;
            else
                rank += i.Value;
        }
    }

    public float getRank () {
        return rank;
    }

    public float getTraitValue (Trait t) {
        return personVal.getValue (t);
    }

}
