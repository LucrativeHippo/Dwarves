using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	[System.Serializable]

public class Quests : MonoBehaviour {
	[System.Serializable]
	public class QuestType{
		public Goal goal;public int difficulty;public bool take; 
		public string Name;
		public Sprite img;
		public QuestType(Goal g, int diff, string msg, bool give=false){
			this.goal = g;
			this.difficulty = diff;
			this.Name = msg;
			this.take = give;
			this.img = null;
		}
	};
	
	// For use with generation
	public static QuestType [] list = new QuestType[]{
		// Quests to give resources
		new QuestType(giveWood, 2, "wood",true),
		new QuestType(giveFood, 30, "food",true),
		new QuestType(giveCoal, 60, "coal",true),
		new QuestType(giveStone, 6, "stone",true),
		new QuestType(giveIron, 60, "iron",true),
		// GOLD???
		new QuestType(giveDiamond, 600, "diamond",true),

		
		//new QuestType(isPopulationAbove,10, "population"),
		//new QuestType(isTownCenterAbove,30, "town center level"),
		//new QuestType(hasEmptyHouses,50, "empty houses"),

		// Quests for food above amount
		new QuestType(isFoodAbove, 0, "food"),
		new QuestType(isStoneAbove, 3, "stone"),
		new QuestType(isIronAbove,30,"iron"),
		new QuestType(isCoalAbove,30,"coal"),
		new QuestType(isDiamondAbove,300,"diamond"),
		new QuestType(isWoodAbove, 0, "wood")

	};
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public int getDifficulty(Goal g){
		for (int i = 0; i < list.Length; i++) {
			if (g == list [i].goal)
				return list[i].difficulty;
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
	/// Is the population above a.
	/// </summary>
	/// <returns><c>true</c>, if population above was ised, <c>false</c> otherwise.</returns>
	/// <param name="a">The alpha component.</param>
	public static bool isPopulationAbove(int a){
		return MetaScript.GetNPC().getCount()>=a;//return 0 >= a;
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
