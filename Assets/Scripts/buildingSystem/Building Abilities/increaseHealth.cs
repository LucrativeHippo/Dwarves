using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseHealth : MonoBehaviour {

    public float multiplierToAdd = 0;

	// Use this for initialization
	void Start () {
        MetaScript.getGlobal_Stats().setHealthMultiplier(multiplierToAdd);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
