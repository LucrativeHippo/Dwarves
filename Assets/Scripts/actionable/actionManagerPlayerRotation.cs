using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionManagerPlayerRotation : MonoBehaviour {

	public Transform player;
	public float radious = 1f;

	void Start() {
		player = transform.parent.transform;
	}

	void Update() {
		Vector3 actionboxToMouse = Camera.main.ScreenToWorldPoint (Input.mousePosition) - player.position;
		actionboxToMouse.z = 0;
		transform.position = player.position + (radious * actionboxToMouse.normalized);
	}


}
