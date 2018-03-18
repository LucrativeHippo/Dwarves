using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickup : MonoBehaviour, IActionable {

    [NamedArray(typeof(ResourceTypes))]
    public int[] amount = new int[(int)ResourceTypes.NumberOfTypes];


    public void recieveAction()
    {
        for (int i = 0; i < amount.Length; i++)
        {
            MetaScript.getRes().addResource(i, amount[i]);
        }
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
