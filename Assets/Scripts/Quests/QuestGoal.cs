using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: remove MonoBehaviour
public class QuestGoal : MonoBehaviour {
	
	Quests.Goal isCompleted;
	int threshold;
	// Use this for initialization
	void Start () {
		isCompleted = Quests.isPopulationAbove;
		//threshold = 4;
		threshold = 6 - Quests.getDifficulty(isCompleted);
	}
	
	// TODO: replace with interactable calls
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			print(isGoalComplete());
		}
	}

	public QuestGoal(int rank){
		// randomly generate based on rank
		do{
			// select index at random
			int randNum = Random.Range(0,Quests.goalArr.Length-1);
			isCompleted = Quests.goalArr [randNum];
			threshold = rank - Quests.getDifficulty(isCompleted);
		}while (threshold <= 0);


	}

	/// <summary>
	/// Checks for goal completion.
	/// </summary>
	/// <returns><c>true</c>, if goal completed, <c>false</c> otherwise.</returns>
	public bool isGoalComplete(){
		return isCompleted (threshold);
	}




}
