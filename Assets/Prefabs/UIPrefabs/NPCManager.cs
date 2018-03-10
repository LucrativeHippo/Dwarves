using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour {

    private List<GameObject> NPCs;

    [SerializeField] private GameObject buttonParent;
    [SerializeField] private GameObject Button_Template;

    [SerializeField] private GameObject mainUIGameObject;
    [SerializeField] private GameObject NPCManagerGameObject;
    [SerializeField] private GameObject mainDisplayGameObject;
    [SerializeField] private GameObject mainDisplayContent;

    [SerializeField] private KeyCode exitKey;

    private bool NPCManagerMenuEnabled;

    /// <summary>
    /// Start this instance and check if there are any OwnedNPCs in the World.
    /// </summary>
    void Start () {
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
            tempGameObject.transform.SetParent (buttonParent.transform, false);
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
