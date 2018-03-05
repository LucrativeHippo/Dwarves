using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionManagerPlayerRotation : MonoBehaviour {

	public float radius = 1f;


	void Start() {
		transform.localPosition = new Vector3(0, 0, radius);
	}

	void FixedUpdate() {

		//actionboxDirection.z = 0;
	}

	public void setRotation(Vector3 direction){
		if(!direction.Equals(Vector3.zero))
			transform.localPosition = direction * radius;
	}

}
