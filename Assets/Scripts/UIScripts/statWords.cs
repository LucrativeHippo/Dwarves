using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statWords : MonoBehaviour {

    private GameObject MoreDetailsUIObject;

    private GameObject currentNPC;

    private float[] skills;
    private int[] indexRating;


    public void setNPC (GameObject aNPC) {
        currentNPC = aNPC;
        getSkills ();
        decideStrength ();
    }

    private void getSkills () {
        skills = currentNPC.GetComponent<Skills> ().skillLevel;
        indexRating = currentNPC.GetComponent<npcJobRating>().getBestIndex();
    }

    private void decideStrength () {
        MoreDetailsUIObject = this.gameObject;

        string skillWordString = "";
        for (int i = 0; i < skills.Length; i++) {
            if (skills [i] >= 7) {
                skillWordString += "Strong " + ((Skills.list)i).ToString () + "\n"; 
            } else if (skills [i] <= 3) {
                skillWordString += "Weak " + ((Skills.list)i).ToString () + "\n";
            }
        }
        if (skillWordString == "")
        {

        }

        else
        {
            skillWordString += "\n\n";
        }
        skillWordString += "Recommended Job: " + "\n";

        switch (indexRating[0])
        {
            case 0:
                skillWordString += "Food" ;
                break;
            case 1:
                skillWordString += "Mining" ;
                break;
            case 2:
                skillWordString += "Wood";
                break;
            case 3:
                skillWordString += "Guard";
                break;
        }
        if (indexRating[1] != 0)
        {
            switch (indexRating[1])
            {
                case 0:
                    skillWordString += " or Food" + "\n";
                    break;
                case 1:
                    skillWordString += " or Mining" + "\n";
                    break;
                case 2:
                    skillWordString += " or Wood\n";
                    break;
                case 3:
                    skillWordString += " or Guard\n";
                    break;
            }
        }
        MoreDetailsUIObject.transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = skillWordString;
    }

}
