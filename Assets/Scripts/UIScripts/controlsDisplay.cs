using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlsDisplay : MonoBehaviour {

    private GameObject controlsHelp;
    private Controls controls;

    void Start () {
        controlsHelp = this.transform.GetChild (4).gameObject;
        controls = MetaScript.GetControls ();
    }
    
    void Update () {
        if (controls.keyDown(controls.ControlsDisplay)) {
            Debug.Log ("Key Down");
            controlsHelp.SetActive(true);
        } else if (controls.keyUp (controls.ControlsDisplay)){
            Debug.Log ("Key Up");
            controlsHelp.SetActive (false);
        }
    }
}
