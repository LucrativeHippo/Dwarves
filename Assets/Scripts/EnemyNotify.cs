using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNotify : MonoBehaviour {
	ArrayList followers;
	// Use this for initialization
	void Start () {
		followers = new ArrayList();
	}

	public void beingTargeted(GameObject enemy){
		followers.Add(enemy);
	}
	public void stopTargeted(GameObject enemy){
		followers.Remove(enemy);
	}
	/// <summary>
	/// Notifies all enemies that target this npc that it can't be targeted anymore;
	/// </summary>
	public void safe(){
		foreach(GameObject g in followers.ToArray()){
			g.SendMessage("opponentIsSafe");
		}
		followers = new ArrayList();
	}
	
}
