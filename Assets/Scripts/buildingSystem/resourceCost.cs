using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceCost : MonoBehaviour {
	[NamedArray(typeof(ResourceTypes))] public int[] cost = new int[(int)ResourceTypes.NumberOfTypes];



	public bool canAfford(){
		for(int i=0;i<cost.Length;i++){
			if(MetaScript.getRes().hasResource(i,cost[i])){
				// Do nothing
			}else{
				return false;
			}
		}
		return true;
	}

	public void purchase(){
		for(int i=0;i<cost.Length;i++){
			MetaScript.getRes().addResource(i,-cost[i]);
		}
	}

}
