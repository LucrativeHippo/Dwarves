using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTempResource : MonoBehaviour, IActionable {
    public QuestResourceManager.ResourceTypes myType;
    public void recieveAction()
    {
        MetaScript.getRes().addResource(myType,1);
		
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
