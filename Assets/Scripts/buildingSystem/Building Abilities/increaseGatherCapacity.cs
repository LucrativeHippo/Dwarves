using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseGatherCapacity : MonoBehaviour {

    [SerializeField]
    private float gatherIncrease = 0.5f;

	// Use this for initialization
	void Start () {
        MetaScript.getGlobal_Stats().setBaseGather(MetaScript.getGlobal_Stats().getBaseGather() + gatherIncrease);
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
