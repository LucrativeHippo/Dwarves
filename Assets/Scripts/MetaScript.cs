using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaScript : MonoBehaviour {
	QuestResourceManager res;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<ResourceManager>().setFood(0);
		gameObject.GetComponent<ResourceManager>().setSand(0);
		gameObject.GetComponent<ResourceManager>().setWood(0);
        res = MetaScript.getRes();

	}
	
	private static GameObject getMetaObject(){
		return GameObject.Find("Meta");
	}

	public static MetaScript getMeta(){
		return getMetaObject().GetComponent<MetaScript>();
	}

	public static QuestResourceManager getRes(){
		return getMetaObject().GetComponent<QuestResourceManager>();
	}

	public static void updateHud(){
		GameObject.Find("Main Camera").GetComponent<HUD>().updateHUD();
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
            //res.setFood(res.getFood()+1);
        }
		if(Input.GetKeyDown(KeyCode.Alpha2)){
            //res.setSand(res.getSand()+1);
        }
		if(Input.GetKeyDown(KeyCode.Alpha3)){
            //res.setWood(res.getWood()+1);
            //print(res.getWood());
        }
		
	}
}
