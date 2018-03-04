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
		//new QuestType(isPopulationAbove,2, "population", 5),
		//new QuestType(isTownCenterAbove,30, "town center level"),
		//new QuestType(hasEmptyHouses,50, "empty houses"),

		new QuestType(isSandAbove, 2, "sand"),
		new QuestType(isStoneAbove, 5, "stone"),
		new QuestType(isIronAbove,10,"iron"),
		new QuestType(isCoalAbove,8,"coal"),
		new QuestType(isDiamondAbove,20,"diamond"),
		new QuestType(isWoodAbove, 0, "wood")

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
		return MetaScript.getRes().getResource(ResourceTypes.FOOD) >= a;
	}

	public static bool isStoneAbove(int a){
		return MetaScript.getRes().getResource(ResourceTypes.STONE) >= a;
	}

	public static bool isSandAbove(int a){
		return MetaScript.getRes().getResource(ResourceTypes.SAND) >= a;
	}

	public static bool isWoodAbove(int a){
		return MetaScript.getRes().getResource(ResourceTypes.WOOD) >= a;
	}

	public static bool isCoalAbove(int a){
		return MetaScript.getRes().getResource(ResourceTypes.COAL) >= a;
	}
	
	public static bool isIronAbove(int a){
		return MetaScript.getRes().getResource(ResourceTypes.IRON) >= a;
	}
	public static bool isGoldAbove(int a){
		return MetaScript.getRes().getResource(ResourceTypes.GOLD) >= a;
	}
	public static bool isDiamondAbove(int a){
		return MetaScript.getRes().getResource(ResourceTypes.DIAMOND) >= a;
	}

	/// <summary>
	/// TODO: Is the population above a/5.
	/// </summary>
	/// <returns><c>true</c>, if population above was ised, <c>false</c> otherwise.</returns>
	/// <param name="a">The alpha component.</param>
	public static bool isPopulationAbove(int a){
		return true;//return 0 >= a;
	}

	/// <summary>
	/// TODO: complete this
	/// </summary>
	/// <param name="a"></param>
	/// <returns></returns>
	public static bool isTownCenterAbove(int a){
		return true;
	}

	/// <summary>
	/// TODO: COMPLETE THIS
	/// </summary>
	/// <param name="a"></param>
	/// <returns></returns>
	public static bool hasEmptyHouses(int a){
		return true;
	}
}
