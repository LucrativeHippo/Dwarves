using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingMenuUiController : MonoBehaviour {

    [SerializeField] KeyCode exitKey;

    private GameObject allUIObject;
    private GameObject buildingMenuObject;

    void Start () {
        allUIObject = GameObject.Find ("AllUIObjectsCanvas");

        buildingMenuObject = allUIObject.transform.GetChild (2).gameObject;
    }

    void Update () {
        if (Input.GetKeyDown (exitKey)) {
            buildingMenuObject.transform.GetChild (0).gameObject.SetActive (false);
            buildingMenuObject.transform.GetChild (1).gameObject.SetActive (false);
            buildingMenuObject.SetActive (false);
        }
    }
}
