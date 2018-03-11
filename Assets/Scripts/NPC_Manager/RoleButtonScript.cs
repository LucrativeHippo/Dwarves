using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RoleButtonScript : MonoBehaviour {

    private GenerateRoleSelector backScript;
    private int collectID;
    private new String name;

    public Text buttonText;

    public void setBackScript (GenerateRoleSelector aBackScript) {
        backScript = aBackScript;
    }

    public void setID (int aNumber) {
        collectID = aNumber;
    }

    public void setName (String aName) {
        name = aName;
        buttonText.text = name;
    }

    public void setListener () {
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => button_Click ());
    }

    private void button_Click () {
        backScript.changeRole (collectID);
    }

}
