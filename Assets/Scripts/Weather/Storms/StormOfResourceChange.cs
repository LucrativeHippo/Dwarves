using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormOfResourceChange : GenericStorm {

    public float multiplier;
    
	// Use this for initialization
	void Start () {
		MetaScript.getGlobal_Stats().setGatherMultiplier(multiplier);
	}
	
    public new void removeStorm()
    {
        MetaScript.getMeta().GetComponent<Global_Stats>().setGatherMultiplier(1f);
        Destroy(gameObject);
    }
}
