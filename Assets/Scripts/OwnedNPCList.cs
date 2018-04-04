using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedNPCList : MonoBehaviour {
    [SerializeField]
    private List<GameObject> NPCs;
    private LinkedList<INPCListener> subscribers = new LinkedList<INPCListener>();

    private GameObject AllUIObjectsCanvas;
    private GameObject UINPCManagerList;
    private GameObject UINPCMoreDetails;

    private void publish(){
        foreach(INPCListener listener in subscribers){
            listener.publish();
        }
    }

	void Start () {
		NPCs = new List<GameObject> ();

        AllUIObjectsCanvas = GameObject.Find ("AllUIObjectsCanvas");
        UINPCManagerList = AllUIObjectsCanvas.transform.GetChild (1).GetChild (0).gameObject;
        UINPCMoreDetails = AllUIObjectsCanvas.transform.GetChild (1).GetChild (1).gameObject;
	}

	
    /// <summary>
    /// Adds a NPC to the List.
    /// </summary>
    /// <param name="newNPC"> a NPC. </param>
    public void addNPC (GameObject newNPC) {
        NPCs.Add (newNPC);
        publish();
    }
	

    /// <summary>
    /// Removes a NPC from the List.
    /// </summary>
    /// <param name="aNPC">A NPC. </param>
    public void removeNPC (GameObject aNPC) {
        NPCs.Remove (aNPC);

        if (UINPCManagerList.activeSelf == true) {
            AllUIObjectsCanvas.transform.GetChild (0).GetChild (0).gameObject.GetComponent<NPCManager> ().reloadMenu ();
        }
        if (UINPCMoreDetails.GetComponent<moreDetailsUIController> ().getCurrentNPC () == aNPC) {
            UINPCMoreDetails.transform.parent.gameObject.GetComponent<npcManagerUIController> ().closeMoreDetails ();
        }

        publish();
    }
	

    /// <summary>
    /// Gets the NPC List.
    /// </summary>
    /// <returns> A List<GameObject> of NPCs.</returns>
    public List<GameObject> getNPCs () {
        return NPCs;
    }

    public int getCount(){
        return NPCs.Count;
    }
}
