using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal : MonoBehaviour {
	
	Quests.Goal isCompleted;
	int threshold;
	// Use this for initialization
	void Start () {
		isCompleted = Quests.isFoodAbove;
		int threshold = 4;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			print(isGoalComplete());
		}
	}

	/// <summary>
	/// Checks for goal completion.
	/// </summary>
	/// <returns><c>true</c>, if goal completed, <c>false</c> otherwise.</returns>
	public bool isGoalComplete(){
		return isCompleted (threshold);
	}




}
