using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedNPCList : MonoBehaviour {
    [SerializeField]
    private List<GameObject> NPCs;

	// Use this for initialization
	void Start () {
		NPCs = new List<GameObject> ();
        GameObject[] temp = GameObject.FindGameObjectsWithTag ("OwnedNPC");

        foreach (var theNPC in temp) {
            NPCs.Add (theNPC);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
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
