using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManagerButtonScript : MonoBehaviour {

    private string name;
    private int number;

    public Text buttonText;
    public NPCManager npcManagerScript;

    private GameObject roleUI;

    private GameObject theNPC;

    public void setName (string aName) {
        name = aName;
        buttonText.text = name;
    }

    public void setListener () {
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => button_Click ());
    }

    public void setNumber (int aNumber) {
        number = aNumber;
        setListener ();
    }

    public void setNPCManagerScript (NPCManager aNPCManagerScript) {
        npcManagerScript = aNPCManagerScript;
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
        roleUI.GetComponent<GenerateRoleSelector> ().setCurrentNPC (theNPC);
        npcManagerScript.buttonClicked (number);
    }
}
