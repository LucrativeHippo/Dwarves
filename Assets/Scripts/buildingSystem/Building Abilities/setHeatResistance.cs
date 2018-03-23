using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setHeatResistance : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MetaScript.getGlobal_Stats().setHasHeatProtection(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
