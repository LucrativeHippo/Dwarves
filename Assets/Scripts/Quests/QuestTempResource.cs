using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTempResource : MonoBehaviour, IActionable {
    public ResourceTypes myType;
    public void recieveAction()
    {
        MetaScript.getRes().addResource(myType,1);
		SendMessage("damage",1);
    }

    public void damage(int x){
        // empty receiver for error avoidance
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
