using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColdResistance : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MetaScript.getGlobal_Stats().setHasColdProtection(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
