using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseMilitary : MonoBehaviour {

    [SerializeField]
    private int numGuards = 1;

    [SerializeField]
    private float militaryAbility = 0.5f;

	// Use this for initialization
	void Start () {
        MetaScript.getGlobal_Stats().setMilitaryAbility(MetaScript.getGlobal_Stats().getMilitaryAbility() + militaryAbility);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
