using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	[System.Serializable]

public class Quests : MonoBehaviour {
	[System.Serializable]
	public class QuestType{
		public Goal goal;
		[ReadOnly] public int difficulty; 
		[ReadOnly] public string Name;
		public Sprite img;
		public QuestType(Goal g, int diff, string msg){
			this.goal = g;
			this.difficulty = diff;
			this.Name = msg;
			this.img = null;
		}
	};

	public static QuestType[] list(){
		return MetaScript.getMeta().GetComponent<Quests>().questList;
	}

	// For use with generation
	public QuestType [] questList = new QuestType[]{
		// Quests to give resources
		new QuestType(giveWood, 2, "wood"),
		new QuestType(giveFood, 5, "food"),
		new QuestType(giveCoal, 15, "coal"),
		new QuestType(giveSand, 4, "sand"),
		new QuestType(giveStone, 10, "stone"),
		new QuestType(giveIron, 20, "iron"),
		new QuestType(giveDiamond, 40, "diamond"),

		
		//new QuestType(isPopulationAbove,2, "population", 5),
		//new QuestType(isTownCenterAbove,30, "town center level"),
		//new QuestType(hasEmptyHouses,50, "empty houses"),

		// Quests for food above amount
		new QuestType(isFoodAbove, 0, "food"),
		new QuestType(isSandAbove, 2, "sand"),
		new QuestType(isStoneAbove, 5, "stone"),
		new QuestType(isIronAbove,10,"iron"),
		new QuestType(isCoalAbove,8,"coal"),
		new QuestType(isDiamondAbove,20,"diamond"),
		new QuestType(isWoodAbove, 0, "wood"),
		new QuestType(isWoodAbove, 1000, "LOLZ")

	};
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public int getDifficulty(Goal g){
		for (int i = 0; i < questList.Length; i++) {
			if (g == questList [i].goal)
				return questList[i].difficulty;
		}

		return 0;
	}


	public delegate bool Goal (int a);

	private static bool hasRes(ResourceTypes i, int a){
		return MetaScript.getRes().hasResource(i,a);
	}
	private static bool takeRes(ResourceTypes i, int a){
		if(hasRes(i,a)){
			MetaScript.getRes().addResource(i,-a);
			return true;
		}
		return false;
	}

	// TODO: add more functions
	/// <summary>
	/// Sees if the food is above a.
	/// </summary>
	/// <returns><c>true</c>, if food above was above a, <c>false</c> otherwise.</returns>
	/// <param name="a">The alpha component.</param>
	public static bool isFoodAbove(int a){
		return hasRes(ResourceTypes.FOOD, a);
	}

	public static bool isStoneAbove(int a){
		return hasRes(ResourceTypes.STONE, a);
	}

	public static bool isSandAbove(int a){
		return hasRes(ResourceTypes.SAND, a);
	}

	public static bool isWoodAbove(int a){
		return hasRes(ResourceTypes.WOOD, a);
	}

	public static bool isCoalAbove(int a){
		return hasRes(ResourceTypes.COAL, a);
	}
	
	public static bool isIronAbove(int a){
		return hasRes(ResourceTypes.IRON, a);
	}
	public static bool isGoldAbove(int a){
		return hasRes(ResourceTypes.GOLD, a);
	}
	public static bool isDiamondAbove(int a){
		return hasRes(ResourceTypes.DIAMOND, a);
	}

	public static bool giveWood(int a){
		return takeRes(ResourceTypes.WOOD, a);
	}
	public static bool giveFood(int a){
		return takeRes(ResourceTypes.FOOD, a);
	}
	public static bool giveStone(int a){
		return takeRes(ResourceTypes.STONE, a);
	}
	public static bool giveSand(int a){
		return takeRes(ResourceTypes.SAND, a);
	}
	public static bool giveCoal(int a){
		return takeRes(ResourceTypes.COAL, a);
	}
	public static bool giveIron(int a){
		return takeRes(ResourceTypes.IRON, a);
	}
	public static bool giveGold(int a){
		return takeRes(ResourceTypes.GOLD, a);
	}
	public static bool giveDiamond(int a){
		return takeRes(ResourceTypes.DIAMOND, a);
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
