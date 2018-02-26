using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {


	public void updateHUD(){
		QuestResourceManager res = MetaScript.getRes();
		UnityEngine.UI.Text resHUD = gameObject.GetComponentInChildren<UnityEngine.UI.Text>();

		resHUD.text="Wood: " + res.getResource(QuestResourceManager.ResourceTypes.WOOD)
		+ "\nFood: " + res.getResource(QuestResourceManager.ResourceTypes.FOOD);

	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		updateHUD();
	}
}
