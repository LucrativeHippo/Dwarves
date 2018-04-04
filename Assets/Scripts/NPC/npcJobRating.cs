using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcJobRating : MonoBehaviour {
    private float[] skillList;
    private float[] jobRatingList = new float[4];
	// Use this for initialization
	void Start () {
        getSkills();
        getRating();
        Debug.Log(getBestIndex()[0]);
        Debug.Log(getBestIndex()[1]);

	}
	

    void getSkills(){
        skillList = gameObject.GetComponent<Skills>().skillLevel;
    }

    void getRating(){
        //food rating(motivation and skill)
        jobRatingList[0] = skillList[3] + skillList[4];
        //mining rating(strength and motivation)
        jobRatingList[1] = skillList[1] + skillList[3];
        //food rating(strength and charisma)
        jobRatingList[2] = skillList[1] + skillList[2];
        //guard rating(strenth and braveness)
        jobRatingList[3] = skillList[0] + skillList[1];
        for (int i = 0; i < 4; i++){
            Debug.Log(i + " :" + jobRatingList[i]);
        }
    }

    public int[] getBestIndex(){
        int[] index = new int[2];
        index[0] = 0;
        for (int i = 0; i < 3; i++){
            if (jobRatingList[i + 1] > jobRatingList[index[0]])
                index[0] = i + 1;
        }
        for (int i = 0; i < 3; i++){
            if (jobRatingList[i+1] == jobRatingList[index[0]]&& index[0] != i+1){
                index[1] = i + 1;
            }
        }
        return index;
    }

}
