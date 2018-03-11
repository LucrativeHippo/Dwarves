using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour {

    private List<GameObject> NPCs;

    [SerializeField] private GameObject Button_Template;

    private GameObject AllUIObjects;
    private GameObject NPCManagerGameObject;
    private GameObject mainUIGameObject;
    private GameObject mainDisplayGameObject;
    private GameObject mainDisplayContent;

    [SerializeField] private KeyCode exitKey;

    private bool NPCManagerMenuEnabled;

    void Start () {

        AllUIObjects = GameObject.Find ("AllUIObjectsCanvas");
        mainUIGameObject = AllUIObjects.transform.GetChild (0).gameObject;
        NPCManagerGameObject = AllUIObjects.transform.GetChild (1).gameObject;

        mainDisplayGameObject = NPCManagerGameObject.transform.GetChild (0).gameObject;
        mainDisplayContent = mainDisplayGameObject.transform.GetChild (0).GetChild (0).gameObject;

        NPCs = new List<GameObject> ();
        GameObject[] temp = GameObject.FindGameObjectsWithTag ("OwnedNPC");

        foreach (var theNPC in temp) {
            NPCs.Add (theNPC);
        }

        NPCManagerMenuEnabled = false;
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => enableMenu ());
    }

    private void enableMenu () {
        NPCManagerMenuEnabled = true;
        generateUI ();
        mainUIGameObject.SetActive (false);
        NPCManagerGameObject.SetActive (true);
        mainDisplayGameObject.SetActive (true);
    }

    private void disableMenu () {
        NPCManagerMenuEnabled = false;
        mainUIGameObject.SetActive (true);
        mainDisplayGameObject.SetActive (false);
        NPCManagerGameObject.SetActive (false);
        clearUI ();
    }

    void FixedUpdate () {
        if (NPCManagerMenuEnabled && Input.GetKey (exitKey)) {
            disableMenu ();
        }
    }

    private void clearUI () {
        foreach (Transform child in mainDisplayContent.transform) {
            Destroy (child.gameObject);
        }
    }

    /// <summary>
    /// Generates the UI for the NPC's.
    /// </summary>
    private void generateUI () {
        GameObject tempGameObject;
        foreach (var theNPC in NPCs) {
            tempGameObject = Instantiate (Button_Template) as GameObject;
            tempGameObject.SetActive (true);
            mainDisplay aButtonScript = tempGameObject.GetComponent<mainDisplay> ();
            aButtonScript.setNPC (theNPC);
            tempGameObject.transform.SetParent (mainDisplayContent.transform, false);
        }
    }

    /// <summary>
    /// Adds a NPC to the List.
    /// </summary>
    /// <param name="newNPC"> a NPC. </param>
    public void addNPC (GameObject newNPC) {
        NPCs.Add (newNPC);
    }

    /// <summary>
    /// Removes a NPC from the List.
    /// </summary>
    /// <param name="aNPC">A NPC. </param>
    public void removeNPC (GameObject aNPC) {
        NPCs.Remove (aNPC);
    }

    /// <summary>
    /// Gets the NPC List.
    /// </summary>
    /// <returns> A List<GameObject> of NPCs.</returns>
    public List<GameObject> getNPCs () {
        return NPCs;
    }
}
