using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLight : MonoBehaviour {
	Vector3 tc;
	GameObject player;
	// Use this for initialization
	void Start () {
		tc = MetaScript.getTownCenter().transform.position;
		player = MetaScript.getPlayer();
	}
	float maxIntensity = 0.6f;
	float minIntensity = 0.2f;

	float thresholdDist = 15f;
	// Update is called once per frame
	void Update () {
		Vector3 length = (player.transform.position-tc);
		//float sqrthreshold = thresholdDist*thresholdDist;

		if(Mathf.Abs(length.x)>thresholdDist || Mathf.Abs(length.z)>thresholdDist){
			GetComponent<Light>().intensity = minIntensity;
		}else{
			float dist = length.z;
			if(Mathf.Abs(length.x)>Mathf.Abs(length.z)){
				dist = length.x;
			}
			dist = Mathf.Abs(dist);
			GetComponent<Light>().intensity = (dist/thresholdDist)*(minIntensity-maxIntensity)+maxIntensity;
		}

		// if(dist>sqrthreshold){
		// 	GetComponent<Light>().intensity = minIntensity;
		// }else{
		// 	GetComponent<Light>().intensity = (dist/sqrthreshold)*(minIntensity-maxIntensity)+maxIntensity;
		// }
		
	}
}
