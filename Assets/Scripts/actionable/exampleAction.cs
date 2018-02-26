using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exampleAction : MonoBehaviour, IActionable {

	public void recieveAction(){ 
		Debug.Log ("MessageRecieve");
	}
}
