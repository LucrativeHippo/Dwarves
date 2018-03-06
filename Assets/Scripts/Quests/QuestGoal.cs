using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal {
	[SerializeField]
	private int goalIndex;
	[SerializeField] int threshold;
	
	// void Start () {
	// 	isCompleted = Quests.isPopulationAbove;
	// 	//threshold = 4;
	// 	threshold = 6 - Quests.getDifficulty(isCompleted);
	// }
	

	public QuestGoal(int rank){
		if(rank<=0){
			rank = 1;
			Debug.LogWarning("Tried to insert non positive rank. Defaulting to 1");
		}
        // randomly generate based on rank
        int numberOfTries = 0;
        
		do{
            if (numberOfTries > 10)
            {
                Debug.LogWarning("Tried creating quests far too many times");
                threshold = rank;
                goalIndex = 0;
                Quests.QuestType qq = Quests.questList[goalIndex];
                isCompleted = qq.goal;
            }
			// select index at random
			goalIndex = Random.Range(0,Quests.questList.Length-1);
			
			int difficulty = Quests.questList[goalIndex].difficulty;

			threshold = (rank - difficulty);
			if(threshold>0 && difficulty>0){
				threshold /= difficulty;
				threshold++;
			}
            numberOfTries++;
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
		return Quests.questList[goalIndex].goal (threshold);
	}

	public int getGoalIndex(){
		return goalIndex;
	}
	public int getThreshold(){
		return threshold;
	}


}
