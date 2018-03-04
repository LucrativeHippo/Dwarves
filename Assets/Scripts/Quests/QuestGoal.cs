using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal {
	private int goalIndex;
	Quests.Goal isCompleted;
	int threshold;
	
	// void Start () {
	// 	isCompleted = Quests.isPopulationAbove;
	// 	//threshold = 4;
	// 	threshold = 6 - Quests.getDifficulty(isCompleted);
	// }
	

	public QuestGoal(int rank){
		// randomly generate based on rank
		do{
			// select index at random
			goalIndex = Random.Range(0,Quests.questList.Length-1);
			Quests.QuestType q = Quests.questList[goalIndex];
			isCompleted = q.goal;
			threshold = (rank - q.difficulty);
			if(threshold>0 && q.difficulty>0){
				threshold /= q.difficulty;
				threshold++;
			}
		}while (threshold <= 0);
	}
	
	public QuestGoal(int rank, int index){
		setGoalByIndex(index);
		setRank(rank);
	}
	private void setGoalByIndex(int index){
		goalIndex = index;
		if(index>= Quests.questList.Length || index<0){
			Debug.LogError("Tried to create invalid quest type, changing to default.");
			goalIndex = 0;
		}
		Quests.QuestType q = Quests.questList[goalIndex];
		isCompleted = q.goal;
	}

	/// <summary>
	/// Set rank/difficulty of quest. Some quests may subtract or divide from this.
	/// </summary>
	/// <param name="rank">Linear difficulty</param>
	private void setRank(int rank){
		if(goalIndex <0 || goalIndex>=Quests.questList.Length){
			throw new UnityException("Attempted edit rank on uninstantiated variable");
		}
		threshold = rank - Quests.questList[goalIndex].difficulty;
		if(threshold<0){
			Debug.LogWarning("Attempted to create quest rank lower than 1, setting to default 1");
			threshold = 1;
		}
	}


	/// <summary>
	/// Checks for goal completion.
	/// </summary>
	/// <returns><c>true</c>, if goal completed, <c>false</c> otherwise.</returns>
	public bool isGoalComplete(){
		return isCompleted (threshold);
	}

	public int getGoalIndex(){
		return goalIndex;
	}
	public int getThreshold(){
		return threshold;
	}


}
