using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: remove MonoBehaviour
public class QuestGoal : MonoBehaviour {
	
	Quests.Goal isCompleted;
	int threshold;
	// Use this for initialization
	void Start () {
		isCompleted = Quests.isFoodAbove;
		threshold = 4;
	}
	
	// TODO: replace with interactable calls
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
