using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxCollectors : MonoBehaviour {

	int maxCollectors = 1;
	//List<GameObject> collector;
	int curCount = 0;

	public void add(){
		curCount++;//collector.Add(npc);
	}
	public void remove(){
		curCount--;//collector.Remove(npc);
	}

	public bool hasRoom(){
		return curCount<maxCollectors;//return collector.Count<collector.Capacity;
	}
}
