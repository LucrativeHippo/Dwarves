using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	[SerializeField]
	private int [] resourceList = new int[(int)ResourceTypes.NumberOfTypes];

	private bool meat;
    private bool fruit;
    private bool veg;

	/// <summary>
	/// Gets current stored value of selected resource type. 
	/// </summary>
	/// <param name="i"></param>
	/// <returns>Current value of i</returns>
	public int getResource(ResourceTypes i){
		return resourceList[(int)i];
	}

	public void addResource(ResourceTypes i, int add){
		resourceList[(int)i] += add;
	}

	void setResource(ResourceTypes i, int set){
		resourceList[(int)i] = set;
	}

	/// <summary>
	/// True if has at least amount of resource 'i'
	/// </summary>
	/// <param name="i"></param>
	/// <param name="amount"></param>
	/// <returns><c>true</c> If has enough of resource to pay amount, <c>false</c> otherwise.</returns>
	public bool hasResource(ResourceTypes i, int amount){
		return resourceList[(int)i] >= amount;
	}

	/// <summary>
	/// USE AT OWN RISK.
	/// Sets all resources to 0.
	/// </summary>
	public void resetALL(){
		for(int i=0;i<(int)ResourceTypes.NumberOfTypes;i++){
			resourceList[i] = 0;
		}
	}

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
