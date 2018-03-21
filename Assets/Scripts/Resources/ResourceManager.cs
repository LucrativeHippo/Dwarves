using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	[SerializeField]
	[NamedArray(typeof(ResourceTypes))]private int [] resourceList = new int[(int)ResourceTypes.NumberOfTypes];
    [SerializeField]
    [NamedArray(typeof(ResourceTypes))]private int [] maxResourceList = new int[(int)ResourceTypes.NumberOfTypes];
    

    void Awake(){
		resourceList = new int[(int)ResourceTypes.NumberOfTypes];
		maxResourceList = new int[(int)ResourceTypes.NumberOfTypes];
        maxResourceList[(int)ResourceTypes.WOOD] = 200;
        maxResourceList[(int)ResourceTypes.FOOD] = 100;
        maxResourceList[(int)ResourceTypes.STONE] = 50;
        maxResourceList[(int)ResourceTypes.COAL] = 10;
        maxResourceList[(int)ResourceTypes.DIAMOND] = 5;
        maxResourceList[(int)ResourceTypes.GOLD] = 5;
        maxResourceList[(int)ResourceTypes.IRON] = 10;
        maxResourceList[(int)ResourceTypes.POPULATION] = 5;
    }

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

    public void increaseCapacity(int i, int increase)
    {
        maxResourceList[i] += increase;
		MetaScript.updateResourcesUI();
    }

    public int getMaxResource (ResourceTypes aType) {
        return getMaxResource ((int)aType);
    }

    public int getMaxResource (int theIndex) {
        return maxResourceList [theIndex];
    }

	public void addResource(ResourceTypes i, int add){
		addResource((int)i, add);
	}
	
	public void addResource(int i, int add){
        if ((resourceList[i] + add) <= maxResourceList[i])
        {
			resourceList[i] += add;
		}
		else
        {
			setResource(i,maxResourceList[i]);
        }
		MetaScript.updateResourcesUI();
	}

    public bool roomForResource(ResourceTypes i, int add)
    {
        if((resourceList[(int)i] + add) <= maxResourceList[(int)i])
        {
            return true;
        }
        return false;
    }

	void setResource(ResourceTypes i, int set){
		setResource((int)i,set);
	}
	void setResource(int i, int set){
		resourceList[i] = set;
		MetaScript.updateResourcesUI();
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
