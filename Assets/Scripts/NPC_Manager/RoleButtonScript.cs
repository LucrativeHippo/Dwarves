using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RoleButtonScript : MonoBehaviour {

    private GenerateRoleSelector backScript;
    private int collectID;
    private String name;

    public void setRoleButtonScript (GenerateRoleSelector generateRoleSelector) {
        backScript = generateRoleSelector;
    }

    public void setID (int aNumber) {
        collectID = aNumber;
    }

    public void setName (String aName) {
        name = aName;
    }

    public void setListener () {
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => button_Click ());
    }

    private void button_Click () {
        backScript.changeRole (collectID);
    }

}
