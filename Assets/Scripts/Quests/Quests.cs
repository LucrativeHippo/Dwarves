using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour {
	// TODO: possibly remove, static class so far proves more useful
	public List<Goal> goalList;// = new List<Goal>(new IEnumerable<Goal>(isFoodAbove));
	public static Goal [] goalArr = new Goal[]{isFoodAbove};//,isPopulationAbove,isTownCenterAbove,hasEmptyHouses};

	// Use this for initialization
	void Start () {

		goalList = new List<Goal> {isFoodAbove};
		goalArr = new Goal[]{isFoodAbove,isPopulationAbove,isTownCenterAbove,hasEmptyHouses};
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public delegate bool Goal (int a);

	// TODO: add more functions, possibly move meta call to class variable
	public static bool isFoodAbove(int a){
		GameObject meta = GameObject.Find ("Meta");
		return meta.GetComponent<MetaScript> ().getFood () >= a;
	}

	public bool isPopulationAbove(int a){
		return true;
	}

	public bool isTownCenterAbove(int a){
		return true;
	}

	public bool hasEmptyHouses(int a){
		return true;
	}



}
