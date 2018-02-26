using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingResources : MonoBehaviour {

	public int currentWood = 5000;
	public int currentStone = 5000;
	public int currentGold = 5000;

	public void useWood (int cost) {
		currentWood -= cost;
	}

	public void useStone (int cost) {
		currentStone -= cost;
	}

	public void useGold (int cost) {
		currentGold -= cost;
	}

	public int getWood () {
		return currentWood;
	}

	public int getStone () {
		return currentStone;
	}

	public int getGold () {
		return currentGold;
	}
}
