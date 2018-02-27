using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.AccessControl;

public class GenerateRoleSelector : MonoBehaviour {
    private GameObject Button_Template;
    private GameObject RoleSelectorUI;
    private GameObject currentNPC;

    /// <summary>
    /// Start this instance and gets the RoleSelectorUI.
    /// </summary>
    void Start () {
        RoleSelectorUI = GameObject.Find ("NPCManagerSelectRole");
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
            aButtonScript.setRoleButtonScript (this);
            aButtonScript.setName (theType.ToString ());
            aButtonScript.setID (counter);
            tempGameObject.transform.SetParent (RoleSelectorUI.transform, false);
            counter++;
        }

    }

    public void changeRole (int collectID) {
        var types = Enum.GetValues (typeof(ResourceTypes));
        Debug.Log (types.GetValue (collectID));
        currentNPC.GetComponent<collect> ().findingType = ResourceTypes.DIAMOND;
        currentNPC.GetComponent<collect> ().getResource = true;
        RoleSelectorUI.SetActive (false);
    }

    public void setCurrentNPC (GameObject aNPC) {
        currentNPC = aNPC;
    }
}
