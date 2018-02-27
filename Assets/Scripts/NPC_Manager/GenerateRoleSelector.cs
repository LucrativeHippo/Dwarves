using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateRoleSelector : MonoBehaviour {
    private GameObject Button_Template;

    private GameObject RoleSelectorUI;

    private int currentNPC;

    /// <summary>
    /// Start this instance and gets the RoleSelectorUI.
    /// </summary>
    void Start () {
        RoleSelectorUI = GameObject.Find ("NPCManagerSelectRole");
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
            tempGameObject.transform.SetParent (Button_Template.transform.parent, false);
            counter++;
        }

    }

    public void changeRole (int collectID) {
        var types = Enum.GetValues (typeof(ResourceTypes));
        types [collectID];

    }

    public void setCurrentNPC (int number) {
        currentNPC = number;
    }
}
