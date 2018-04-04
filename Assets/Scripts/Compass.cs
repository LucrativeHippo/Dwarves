using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {
	public GameObject tc;
	public GameObject player;
	public GameObject needle;
	// Use this for initialization
	void Start () {
        player = MetaScript.getPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		if(tc == null){
			tc = MetaScript.getTownCenter();
		}
		
		Vector3 targetPosLocal = tc.transform.InverseTransformPoint(player.transform.position);
		var targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.z) * Mathf.Rad2Deg + 180;
		needle.transform.eulerAngles = new Vector3(needle.transform.eulerAngles.x, 0, targetAngle);
	}
}
