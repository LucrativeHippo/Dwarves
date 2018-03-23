﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedNPCList : MonoBehaviour {
    [SerializeField]
    private List<GameObject> NPCs;
    private LinkedList<INPCListener> subscribers = new LinkedList<INPCListener>();

    private void publish(){
        foreach(INPCListener listener in subscribers){
            listener.publish();
        }
    }
	// Use this for initialization
	void Start () {
		NPCs = new List<GameObject> ();
        //GameObject[] temp = GameObject.FindGameObjectsWithTag ("OwnedNPC");

        //Transform metaParent = MetaScript.getMetaObject().transform;

        // foreach (var theNPC in temp) {
        //     // Add to my list of people
        //     if(theNPC.GetComponent<QuestNPC>() != null && theNPC.transform.parent != metaParent){
        //         theNPC.transform.SetParent(metaParent);
        //         theNPC.GetComponent<QuestNPC>().TakeSoul();
        //     }
        // }
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
        publish();
    }
	

    /// <summary>
    /// Removes a NPC from the List.
    /// </summary>
    /// <param name="aNPC">A NPC. </param>
    public void removeNPC (GameObject aNPC) {
        NPCs.Remove (aNPC);
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
