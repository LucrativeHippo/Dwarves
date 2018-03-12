using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManagerButtonScript : MonoBehaviour {

    private new string name;
    private int number;

    public Text buttonText;

    private GameObject roleUI;
    private GameObject theNPC;

    void Start () {
        roleUI = GameObject.Find ("NPCManagerSelectRole");
    }

    public void setName (string aName) {
        name = aName;
        buttonText.text = name;
    }

    public void setNPC (GameObject aNPC) {
        theNPC = aNPC;
        setName (theNPC.name);
    }

    public void setListener () {
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => button_Click ());
    }

    public void setNumber (int aNumber) {
        number = aNumber;
        setListener ();
    }

    /// <summary>
    /// Sets the role U.
    /// </summary>
    /// <param name="aRoleUI">Role UI GameObject.</param>
    public void setRoleUI (GameObject aRoleUI) {
        roleUI = aRoleUI;
    }

    /// <summary>
    /// On Button Click Set Role.
    /// </summary>
    public void button_Click () {
        this.GetComponent<GenerateRoleSelector> ().setCurrentNPC (theNPC);
        roleUI.GetComponent<Canvas> ().enabled = true;
    }
}
