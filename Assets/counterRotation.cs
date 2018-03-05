using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counterRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Transform t = GetComponentInParent<Transform>();
		gameObject.transform.rotation.Set(gameObject.transform.rotation.x,-t.rotation.y,gameObject.transform.rotation.z,gameObject.transform.rotation.w);
	}
}
