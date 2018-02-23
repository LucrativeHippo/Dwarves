using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBase{
	Queue<QuestGoal> questPath;

	/// <summary>
	/// Create a list of quests of all the same rank
	/// </summary>
	/// <param name="length"></param>
	/// <param name="rank"></param>
	public QuestBase(int length, int rank){
		questPath = new Queue<QuestGoal>();
		for(int i=0;i<length;i++){
			addGoal(new QuestGoal(rank));
		}
	}

	/// <summary>
	/// Adds a goal at the end of the quest list.
	/// </summary>
	/// <param name="goal">Goal.</param>
	public void addGoal(QuestGoal goal){
		if(goal!=null)
			questPath.Enqueue (goal);
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
		if (questPath.Peek ().isGoalComplete ()) {
			questPath.Dequeue ();
			return true;
		}
		return false;
	}

	/// <summary>
	/// Checks to see if the current goal is completed.
	/// </summary>
	/// <returns><c>true</c>, if all quests are completed <c>false</c> otherwise.</returns>
	public bool checkQuest(){
		checkGoal();
		return completed();
	}

	public QuestGoal GetQuestGoal(){
		return questPath.Peek();
	}
}
