using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statWords : MonoBehaviour {

    private GameObject MoreDetailsUIObject;

    private GameObject currentNPC;

    private float[] skills;

    public void setNPC (GameObject aNPC) {
        currentNPC = aNPC;
        getSkills ();
        decideStrength ();
    }

    private void getSkills () {
        skills = currentNPC.GetComponent<Skills> ().skillLevel;
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
        MoreDetailsUIObject.transform.GetChild (5).GetChild (0).GetChild (0).GetChild (0).gameObject.GetComponent<Text> ().text = skillWordString;
    }
    
}
