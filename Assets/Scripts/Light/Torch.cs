using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {
	Light torch;
	// Use this for initialization
	void Start () {
		torch = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)){
			torch.enabled = !torch.enabled;
		}
		if(Debug.isDebugBuild){
			if(Input.GetKey(KeyCode.UpArrow)){
				torch.intensity += .1f;
			}
			if(Input.GetKey(KeyCode.DownArrow)){
				torch.intensity -= .1f;
			}
			if(Input.GetKey(KeyCode.LeftArrow)){
				torch.spotAngle -= .2f;
			}
			if(Input.GetKey(KeyCode.RightArrow)){
				torch.spotAngle += .2f;
			}
		}
	}
}
