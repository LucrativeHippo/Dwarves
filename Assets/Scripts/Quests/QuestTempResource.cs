using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTempResource : MonoBehaviour, IActionable {
    public ResourceTypes myType;
	private bool hasSound =false;

	public void Start(){
		if (GetComponent<AudioSource> () != null) {
			hasSound = true;
		}
	}

	public void recieveAction()
    {
        MetaScript.getRes().addResource(myType,1);
		SendMessage("damage",1);
		if (hasSound) {
			GetComponent<AudioSource> ().Play();
		}
    }

    public void damage(int x){
        // empty receiver for error avoidance
    }
}
