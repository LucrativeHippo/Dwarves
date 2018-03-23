using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decreaseFoodConsumption : MonoBehaviour {
    [SerializeField]
    private float foodConsumption = 1.5f;

    

	// Use this for initialization
	void Start () {
        MetaScript.getGlobal_Stats().setFoodSaved(MetaScript.getGlobal_Stats().getFoodSaved() + foodConsumption);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
