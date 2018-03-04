using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour {
	public string objName="";
	private GameObject lockOn;
	// Use this for initialization
	private void getLockOn(){
		lockOn = GameObject.FindGameObjectWithTag(objName);
	}
	void Start () {
		getLockOn();
	}
	
	// Update is called once per frame
	void Update () {
		getLockOn();
		if(lockOn!= null){
		Vector3 camPos = gameObject.transform.position;
		Vector3 targetPos = lockOn.transform.position;


		gameObject.transform.SetPositionAndRotation (new Vector3(targetPos.x, 0, targetPos.z),gameObject.transform.rotation);
		}
	}
}
