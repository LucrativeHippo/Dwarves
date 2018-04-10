using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcManagerUIController : MonoBehaviour {

    [SerializeField] private KeyCode exitKey;

    private GameObject allUIObject;
    private GameObject npcManager;
    private GameObject npcDisplay;
    private GameObject moreDetails;
    private GameObject roleSelect;
    private Controls controls;

    void Start () {
        allUIObject = GameObject.Find ("AllUIObjectsCanvas");

        npcManager = allUIObject.transform.GetChild (0).GetChild (0).gameObject;

        npcDisplay = allUIObject.transform.GetChild (1).GetChild (0).gameObject;
        moreDetails = allUIObject.transform.GetChild (1).GetChild (1).gameObject;
        roleSelect = allUIObject.transform.GetChild (1).GetChild (2).gameObject;
        controls = MetaScript.GetControls();
    }

    void Update () {
        if (controls.keyDown(controls.ExitUI)) {
            if (npcDisplay.activeSelf) {
                closeNPCManager ();
            } else if (roleSelect.activeSelf) {
                closeRoleSelect ();
            } else if (moreDetails.activeSelf) {

            }
        }
    }

    public void closeNPCManager() {
        npcManager.GetComponent<NPCManager> ().disableMenu ();
    }

    public void closeRoleSelect() {
        roleSelect.SetActive (false);
    }

    public void closeMoreDetails() {
        moreDetails.SetActive (false);
        npcManager.GetComponent<NPCManager> ().enableMenu ();
    }
}
