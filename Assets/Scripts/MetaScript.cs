using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaScript : MonoBehaviour {

	int food;
	int population;
	// Use this for initialization
	void Start () {
		food = 0;
		population = 0;
	}
	
	public static MetaScript getMeta(){
		return GameObject.Find("Meta").GetComponent<MetaScript>();
	}
	// Update is called once per frame
	void Update () {
		
		// Increase food
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			print ("food");
			food++;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			print ("Population");
			population++;
		}
	}

	/// <summary>
	/// Gets the food.
	/// </summary>
	/// <returns>The food.</returns>
	public int getFood(){
		return food;
	}

	public int getPop(){
		return population;
	}
}
