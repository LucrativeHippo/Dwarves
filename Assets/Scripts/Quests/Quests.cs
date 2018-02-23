using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour {
//	public List<Goal> goalList;// = new List<Goal>(new IEnumerable<Goal>(isFoodAbove));
	// For use with generation
	public static Goal [] goalArr = new Goal[]{isFoodAbove,isPopulationAbove,isTownCenterAbove,hasEmptyHouses};
	public static int[] goalDifficulty = new int[]{0,2,30,50};

	// Use this for initialization
	void Start () {

//		goalList = new List<Goal> {isFoodAbove};
//		goalArr = new Goal[]{isFoodAbove,isPopulationAbove,isTownCenterAbove,hasEmptyHouses};
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public static int getDifficulty(Goal g){
		int index = -1;
		for (int i = 0; i < goalArr.Length; i++) {
			if (g == goalArr [i]) {
				index = i;
				break;
			}
		}

		if(index == -1)
			return 0;
		else
			return goalDifficulty [index];
	}


	public delegate bool Goal (int a);

	private static MetaScript getMeta(){
		GameObject meta = GameObject.Find ("Meta");
		return meta.GetComponent<MetaScript> ();
	}

	// TODO: add more functions, possibly move meta call to class variable
	/// <summary>
	/// Sees if the food is above a.
	/// </summary>
	/// <returns><c>true</c>, if food above was above a, <c>false</c> otherwise.</returns>
	/// <param name="a">The alpha component.</param>
	public static bool isFoodAbove(int a){
		return getMeta().getFood () >= a;
	}

	/// <summary>
	/// Is the population above a/5.
	/// </summary>
	/// <returns><c>true</c>, if population above was ised, <c>false</c> otherwise.</returns>
	/// <param name="a">The alpha component.</param>
	public static bool isPopulationAbove(int a){
		return getMeta().getPop() >= a/5+1;
	}

	public static bool isTownCenterAbove(int a){
		return true;
	}

	public static bool hasEmptyHouses(int a){
		return true;
	}


}
