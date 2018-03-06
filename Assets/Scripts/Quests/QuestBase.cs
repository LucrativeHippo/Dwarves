using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestBase{
	public List<QuestGoal> questPath;

	/// <summary>
	/// Create a list of quests of all the same rank
	/// </summary>
	/// <param name="length"></param>
	/// <param name="rank"></param>
	public QuestBase(int length, int rank){
		questPath = new List<QuestGoal>();
		/* Create with decreasing difficulty
		int maxRank = rank - length;
		for(int i=0;i<length;i++){
			maxRank++;
			int tempRank = Random.Range(1,maxRank);
			addGoal(new QuestGoal(tempRank));
			maxRank -= tempRank;
		}
		*/
		if(length<=0){
			Debug.LogWarning("Tried to create list of non-positive number");
			length = 1;
		}
		createRecursively(length,rank);
	}

	private void createRecursively(int length, int rank){
		if(rank<=0){
			rank = 1;
			Debug.LogWarning("Tried to input non-positive rank. Default: 1");
		}
		int tempRank = rank;
		if(length>0){
			tempRank = Random.Range(1,rank-length+1);
			createRecursively(length-1, rank-tempRank);
		}

		addGoal(new QuestGoal(tempRank));
	}

	public QuestBase(int rank){
		questPath = new List<QuestGoal>();
		createRecursively(1,rank);
	}

	public QuestBase(){
		questPath = new List<QuestGoal>();
	}

	/// <summary>
	/// Adds a goal at the end of the quest list.
	/// </summary>
	/// <param name="goal">Goal.</param>
	public void addGoal(QuestGoal goal){
		if(goal!=null)
			questPath.Add (goal);
		else
			Debug.LogWarning("Attempted to add empty goal");
	}

	/// <summary>
	/// Checks if all quests are completed
	/// </summary>
	private bool completed(){
		return questPath.Count == 0;
	}

	/// <summary>
	/// Checks if goal is complete. If it is remove from queue.
	/// </summary>
	private bool checkGoal(){
		if (GetQuestGoal().isGoalComplete ()) {
			questPath.RemoveAt(0);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Checks to see if the current goal is completed.
	/// </summary>
	/// <returns><c>true</c>, if all quests are completed <c>false</c> otherwise.</returns>
	public bool checkQuest(){
		if(questPath.Count != 0)
			checkGoal();
		return completed();
	}

	public QuestGoal GetQuestGoal(){
		return questPath.ToArray()[0];
	}
}
