using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingMenuUiController : MonoBehaviour {


    private GameObject allUIObject;
    private GameObject buildingMenuObject;
    private Controls controls;

    void Start () {
        allUIObject = GameObject.Find ("AllUIObjectsCanvas");

        buildingMenuObject = allUIObject.transform.GetChild (2).gameObject;
        controls = MetaScript.GetControls();
    }

    void Update () {
        if (controls.keyDown(controls.ExitUI)) {
            closeBuildingUI ();
        }
    }

    public void closeBuildingUI() {
        buildingMenuObject.transform.GetChild (0).gameObject.SetActive (false);
        buildingMenuObject.transform.GetChild (1).gameObject.SetActive (false);
        buildingMenuObject.SetActive (false);
    }
}
