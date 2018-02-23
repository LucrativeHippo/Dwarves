using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    private GameObject mainUI;
    private GameObject npcManagerCanvas;
    private bool menuEnabled;


    // Use this for initialization
    void Start () {
        npcManagerCanvas = GameObject.Find ("NPCManagerCanvas");
        npcManagerCanvas = GameObject.Find ("MainUICanvas");
    }

    private void enableMenu () {
        mainUI.GetComponent<Canvas> ().enabled = menuEnabled;
        menuEnabled = !menuEnabled;
        npcManagerCanvas.GetComponent<Canvas> ().enabled = menuEnabled;
    }

}
