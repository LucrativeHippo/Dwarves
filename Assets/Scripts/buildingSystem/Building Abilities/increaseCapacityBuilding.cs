using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseCapacityBuilding : MonoBehaviour {

    [SerializeField]
    [NamedArray(typeof(ResourceTypes))]public int[] maxAmount = new int[(int)ResourceTypes.NumberOfTypes];


    // Use this for initialization
    void Start () {
        for (int i = 0; i < (int)ResourceTypes.NumberOfTypes; i++)
        {
            MetaScript.getRes().increaseCapacity(i, maxAmount[i]);
        }
      
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
