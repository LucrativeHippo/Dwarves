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
            buildingMenuObject.SetActive (false);
        }
    }
}
