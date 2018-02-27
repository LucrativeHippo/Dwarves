using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCManager : MonoBehaviour {

    private List<GameObject> NPCs;

    GameObject Button_Template;


    /// <summary>
    /// Start this instance and check if there are any OwnedNPCs in the World.
    /// </summary>
    void Start () {
        GameObject[] temp = GameObject.FindGameObjectsWithTag ("OwnedNPC");
        foreach (var theNPC in temp) {
            addNPC (theNPC);
        }
    }

    /// <summary>
    /// Changes the role of a Specific NPC by ID number.
    /// </summary>
    /// <param name="characterID">Character I.</param>
    /// <param name="newRole">New role.</param>
    public void changeRole (int characterID, String newRole) {
        NPCs [characterID].GetComponent<NPCDetails> ().setRole (newRole);
    }

    /// <summary>
    /// Generates the UI for the NPC's.
    /// </summary>
    public void generateUI () {
        GameObject tempGameObject;
        int counter = 0;
        foreach (var theNPC in NPCs) {
            tempGameObject = Instantiate (Button_Template) as GameObject;
            tempGameObject.SetActive (true);
            NPCManagerButtonScript aButtonScript = tempGameObject.GetComponent<NPCManagerButtonScript> ();
            aButtonScript.setNPCManagerScript (this);
            aButtonScript.setName (theNPC.name);
            aButtonScript.setNumber (counter);
            tempGameObject.transform.SetParent (Button_Template.transform.parent, false);
            counter++;
        }
    }

    /// <summary>
    /// Adds a NPC to the List.
    /// </summary>
    /// <param name="newNPC"> a NPC. </param>
    public void addNPC (GameObject newNPC) {
        NPCs.Add (newNPC);
    }

    /// <summary>
    /// Removes a NPC from the List.
    /// </summary>
    /// <param name="aNPC">A NPC. </param>
    public void removeNPC (GameObject aNPC) {
        NPCs.Remove (aNPC);
    }

    public void buttonClicked (int number) {
        
    }
}
