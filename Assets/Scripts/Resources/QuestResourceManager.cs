using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestResourceManager : MonoBehaviour {

	public enum ResourceTypes{
		FOOD,WOOD,STONE,SAND,COAL,IRON,GOLD,DIAMOND,
		NumberOfTypes
	}
	private int [] resourceList = new int[(int)ResourceTypes.NumberOfTypes];

	private bool meat;
    private bool fruit;
    private bool veg;

	public int getResource(ResourceTypes i){
		return resourceList[(int)i];
	}

	public void addResource(ResourceTypes i, int add){
		resourceList[(int)i] += add;
	}

	void setResource(ResourceTypes i, int set){
		resourceList[(int)i] = set;
	}
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
