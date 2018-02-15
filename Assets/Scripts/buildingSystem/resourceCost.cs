using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceCost : MonoBehaviour {

	public int woodCost = 200;
	public int stoneCost = 150;
	public int goldCost = 100;

	public int getWoodCost () {
		return woodCost;
	}

	public int getStoneCost () {
		return stoneCost;
	}

	public int getGoldCost () {
		return goldCost;
	}

}
