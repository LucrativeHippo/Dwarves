using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTest : MonoBehaviour {
	public int[] arr = new int[11];
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<10;i++){
			arr[(int)Skills.rollSkill()]++;
		}
	}
}
