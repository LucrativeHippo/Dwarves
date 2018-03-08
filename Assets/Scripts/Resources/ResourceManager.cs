using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	[SerializeField]
	[NamedArray(typeof(ResourceTypes))]private int [] resourceList = new int[(int)ResourceTypes.NumberOfTypes];

	private bool meat;
    private bool fruit;
    private bool veg;

	/// <summary>
	/// Gets current stored value of selected resource type. 
	/// </summary>
	/// <param name="i"></param>
	/// <returns>Current value of i</returns>
	public int getResource(ResourceTypes i){
		return getResource((int)i);
	}
	public int getResource(int i){
		return resourceList[i];
	}

	public void addResource(ResourceTypes i, int add){
		addResource((int)i,add);
	}
	public void addResource(int i, int add){
		resourceList[i] += add;
	}

	void setResource(ResourceTypes i, int set){
		setResource((int)i,set);
	}
	void setResource(int i, int set){
		resourceList[i] = set;
	}

	/// <summary>
	/// True if has at least amount of resource 'i'
	/// </summary>
	/// <param name="i"></param>
	/// <param name="amount"></param>
	/// <returns><c>true</c> If has enough of resource to pay amount, <c>false</c> otherwise.</returns>
	public bool hasResource(ResourceTypes i, int amount){
		return hasResource((int)i,amount);
	}
	public bool hasResource(int i, int amount){
		return resourceList[i] >= amount;
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
