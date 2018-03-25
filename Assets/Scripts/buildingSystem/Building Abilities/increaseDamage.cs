using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseDamage : MonoBehaviour {

    public float multiplierToAdd = 0;

	// Use this for initialization
	void Start () {
        MetaScript.getGlobal_Stats().setAtkMultiplier(multiplierToAdd);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
