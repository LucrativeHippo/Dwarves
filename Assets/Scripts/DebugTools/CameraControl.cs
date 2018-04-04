using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateMove ();
	}

	void updateMove(){
		int x, y, z;
		x = y = z = 0;

		x += Input.GetKey (KeyCode.LeftArrow) ? -1 : 0;
		x += Input.GetKey (KeyCode.RightArrow) ? 1 : 0;

		y += Input.GetKey (KeyCode.DownArrow) ? -1 : 0;
		y += Input.GetKey (KeyCode.UpArrow) ? 1 : 0;

		z += Input.GetKey (KeyCode.Comma) ? -1 : 0;
		z += Input.GetKey (KeyCode.Period) ? 1 : 0;

		transform.Translate (x, y, 0);
		//gameObject.GetComponent<Camera> () += (float)z;
	}
}
