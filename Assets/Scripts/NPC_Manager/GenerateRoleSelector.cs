using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.AccessControl;

public class GenerateRoleSelector : MonoBehaviour {
    public GameObject Button_Template;
    private GameObject RoleSelectorUI;
    private GameObject currentNPC;

    private GameObject buttonParent;

    /// <summary>
    /// Start this instance and gets the RoleSelectorUI.
    /// </summary>
    void Start () {
        RoleSelectorUI = GameObject.Find ("NPCManagerSelectRole");
        buttonParent = GameObject.Find ("NPCManagerSelectRoleContent");
        generateRolesMenu ();
    }

    /// <summary>
    /// Generates the roles menu.
    /// </summary>
    private void generateRolesMenu () {
        var types = Enum.GetValues (typeof(ResourceTypes));
        GameObject tempGameObject;
        int counter = 0;
        foreach (var theType in types) {
            tempGameObject = Instantiate (Button_Template) as GameObject;
            tempGameObject.SetActive (true);
            RoleButtonScript aButtonScript = tempGameObject.GetComponent<RoleButtonScript> ();
            aButtonScript.setBackScript (this.GetComponent<GenerateRoleSelector> ());
            aButtonScript.setName (theType.ToString ());
            aButtonScript.setID (counter);
            aButtonScript.setListener ();
            tempGameObject.transform.SetParent (buttonParent.transform, false);
            counter++;
        }

    }

    public void changeRole (int collectID) {
        currentNPC.GetComponent<collect> ().findingType = (ResourceTypes)collectID;
        currentNPC.GetComponent<collect> ().getResource = true;
        RoleSelectorUI.GetComponent<Canvas> ().enabled = false;
    }

    public void setCurrentNPC (GameObject aNPC) {
        currentNPC = aNPC;
    }
}
