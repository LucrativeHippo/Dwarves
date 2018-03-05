using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionManagerPlayerRotation : MonoBehaviour {

	public Transform player;
	public float radius = 1f;

	private Vector3 actionboxDirection = new Vector3(0, 0, 10);

	void Start() {
		player = transform.parent.transform;
	}

	void FixedUpdate() {

		//actionboxDirection.z = 0;
	}

	public void setRotation(Vector3 direction){
		actionboxDirection = direction * radius;
		transform.position = player.position + actionboxDirection;

	}

}
