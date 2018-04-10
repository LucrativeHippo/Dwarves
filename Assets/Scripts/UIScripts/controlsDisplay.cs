using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlsDisplay : MonoBehaviour {

    private GameObject controlsHelp;
    private Controls controls;

    private bool toggleBool;

    void Start () {
        controlsHelp = this.transform.GetChild (4).gameObject;
        controls = MetaScript.GetControls ();
        toggleBool = true;
    }
    
    void Update () {
        if (controls.keyDown(controls.ControlsDisplay)) {
            Debug.Log ("Key Down");
            activateImage ();
        } else if (controls.keyUp (controls.ControlsDisplay)){
            Debug.Log ("Key Up");
            disableImage ();
        }
    }

    public void toggleImage () {
        if (toggleBool) {
            activateImage ();
            toggleBool = false;
        } else {
            disableImage ();
            toggleBool = true;
        }
    }

    public void activateImage() {
        controlsHelp.SetActive(true);
    }

    public void disableImage() {
        controlsHelp.SetActive (false);
    }
}
