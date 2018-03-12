using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateRoleSelector : MonoBehaviour {

    private GameObject currentNPC;

    [SerializeField] private GameObject Button_Template;

    private GameObject buttonParent;

    /// <summary>
    /// Start this instance and gets the RoleSelectorUI.
    /// </summary>
    void Start () {
        buttonParent = this.transform.GetChild (0).gameObject;

        generateRolesMenu ();
    }

    /// <summary>
    /// Generates the roles menu.
    /// </summary>
    private void generateRolesMenu () {
        var types = Enum.GetValues (typeof(ResourceTypes));
        GameObject tempGameObject;
        int endpoint = types.Length - 2;
        int counter = 0;
        foreach (var theType in types) {
            if (counter < endpoint) {
                tempGameObject = Instantiate (Button_Template) as GameObject;
                tempGameObject.SetActive (true);
                tempGameObject.GetComponent<RoleButtonScript> ().setButton (currentNPC, (ResourceTypes)counter);
                tempGameObject.transform.SetParent (buttonParent.transform, false);
                counter++;
            }
        }
    }

    public void setCurrentNPC (GameObject aNPC) {
        currentNPC = aNPC;
    }
}
