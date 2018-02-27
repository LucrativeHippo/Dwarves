using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private GameObject mainUI;
    private GameObject npcManagerCanvas;
    private bool menuEnabled;

    public KeyCode exitKey;

    void Start () {
        npcManagerCanvas = GameObject.Find ("NPCManagerCanvas");
        mainUI = GameObject.Find ("MainUICanvas");
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => enableMenu ());
    }

    private void enableMenu () {
        mainUI.GetComponent<Canvas> ().enabled = menuEnabled;
        menuEnabled = !menuEnabled;
        npcManagerCanvas.GetComponent<Canvas> ().enabled = menuEnabled;
    }

    void FixedUpdate () {
        if (menuEnabled && Input.GetKey (exitKey)) {
            Debug.Log ("Test");
            enableMenu ();
        }
    }
}
