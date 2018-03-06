using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private GameObject mainUI;
    private GameObject npcManagerCanvas;
    private bool menuEnabled;

    private GameObject npcManagerContent;

    public KeyCode exitKey;

    void Start () {
        npcManagerCanvas = GameObject.Find ("NPCManagerCanvas");
        mainUI = GameObject.Find ("MainUICanvas");
        npcManagerContent = GameObject.Find ("NPCManagerContent");
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => enableMenu ());
    }

    private void generate () {
        this.GetComponent<NPCManager> ().generateUI ();
    }

    private void enableMenu () {
        mainUI.GetComponent<Canvas> ().enabled = menuEnabled;
        menuEnabled = !menuEnabled;
        npcManagerCanvas.GetComponent<Canvas> ().enabled = menuEnabled;
        if (menuEnabled) {
            generate ();
        }
    }

    void FixedUpdate () {
        if (menuEnabled && Input.GetKey (exitKey)) {
            enableMenu ();
            clearUI ();
        }
    }

    void clearUI () {
        foreach (Transform child in npcManagerContent.transform) {
            Destroy (child.gameObject);
        }
    }
}
