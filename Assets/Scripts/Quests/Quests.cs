using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour {
	public class QuestType{
		public Goal goal;public int difficulty; public string message;
		public int divisor;
		public QuestType(Goal g, int diff, string msg){
			this.goal = g;
			this.difficulty = diff;
			this.divisor = 1;
			this.message = msg;
		}
		public QuestType(Goal g, int diff, string msg, int div){
			
			this.goal = g;
			this.difficulty = diff;
			this.divisor = div;
			this.message = msg;
		}
	};

	// For use with generation
	public static QuestType [] questList = new QuestType[]{
		new QuestType(isFoodAbove, 0, "food"),
		new QuestType(isPopulationAbove,2, "population", 5),
		new QuestType(isTownCenterAbove,30, "town center level"),
		new QuestType(hasEmptyHouses,50, "empty houses")
	};
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public static int getDifficulty(Goal g){
		for (int i = 0; i < questList.Length; i++) {
			if (g == questList [i].goal)
				return questList[i].difficulty;
		}

		return 0;
	}


	public delegate bool Goal (int a);


	// TODO: add more functions
	/// <summary>
	/// Sees if the food is above a.
	/// </summary>
	/// <returns><c>true</c>, if food above was above a, <c>false</c> otherwise.</returns>
	/// <param name="a">The alpha component.</param>
	public static bool isFoodAbove(int a){
		return MetaScript.getMeta().getFood () >= a;
	}

	/// <summary>
	/// Is the population above a/5.
	/// </summary>
	/// <returns><c>true</c>, if population above was ised, <c>false</c> otherwise.</returns>
	/// <param name="a">The alpha component.</param>
	public static bool isPopulationAbove(int a){
		return MetaScript.getMeta().getPop() >= a;
	}

	public static bool isTownCenterAbove(int a){
		return true;
	}

	public static bool hasEmptyHouses(int a){
		return true;
	}


}
