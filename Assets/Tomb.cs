using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb : MonoBehaviour, IActionable {
	string damned;
    public void recieveAction(){
			print("Received action");
			tellPlayer();
    }

    // Use this for initialization
    void Start () {
		damned = "";
	}

	void tellPlayer(){
		if(damned == ""){
			print("The text is faded beyond recognition");
		}else{
			print("Here lies "+damned);
		}
	}

	public void setName(string soul){
		damned = soul;
	}
}
