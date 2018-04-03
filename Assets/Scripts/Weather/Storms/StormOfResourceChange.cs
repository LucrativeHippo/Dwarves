using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormOfResourceChange : GenericStorm {

    public float multiplier;
    
	// Use this for initialization
	void Start () {
		MetaScript.getGlobal_Stats().setGatherMultiplier(multiplier*MetaScript.getGlobal_Stats().getBaseGather());
	}
	
    public override void removeStorm()
    {
        MetaScript.getMeta().GetComponent<Global_Stats>().setGatherMultiplier(MetaScript.getGlobal_Stats().getBaseGather());
        Destroy(gameObject);
    }
}
