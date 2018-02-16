using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBase : MonoBehaviour{
	Queue<QuestGoal> questPath;

	public QuestBase(){
		questPath = new Queue<QuestGoal>();
	}

	/// <summary>
	/// Adds a goal at the end.
	/// </summary>
	/// <param name="goal">Goal.</param>
	private void addGoal(QuestGoal goal){
		if(goal!=null)
			questPath.Enqueue (goal);
	}

	/// <summary>
	/// Checks if all quests are completed
	/// </summary>
	public bool completed(){
		return questPath.Count == 0;
	}

	/// <summary>
	/// Checks if goal is complete. If it is remove from queue.
	/// </summary>
	public void checkGoal(){
		if (questPath.Peek ().isGoalComplete ()) {
			questPath.Dequeue ();
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
