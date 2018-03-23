﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaScript : MonoBehaviour {
	//QuestResourceManager res;
	// Use this for initialization
	static GameObject meta;
	static GameObject tc;
	static GameObject player;
	void Start () {

	}
	
	/// <summary>
	/// Static reference to location of this script
	/// </summary>
	/// <returns></returns>
	public static GameObject getMetaObject(){
		if(meta == null)
			meta = GameObject.Find("Meta");
		return meta;
	}

	
	public static MetaScript getMeta(){
		return getMetaObject().GetComponent<MetaScript>();
	}

	/// <summary>
	/// Static reference to Resource Manager
	/// </summary>
	/// <returns>Resource Manager</returns>
	public static ResourceManager getRes(){
		return getMetaObject().GetComponent<ResourceManager>();
	}
	/// <summary>
	/// Returns the global OwnedNPCList
	/// </summary>
	/// <returns>Owned NPC List</returns>
	public static OwnedNPCList GetNPC(){
		return getMetaObject().GetComponent<OwnedNPCList>();
	}
    public static outpost_controller getOPController()
    {
        return getMetaObject().GetComponent<outpost_controller>();
    }
    public static Global_Stats getGlobal_Stats()
    {
        return getMetaObject().GetComponent<Global_Stats>();
    }

    //  public currentResourcesUIController resourceUI;
    public static void updateResourcesUI(){
        GameObject resObj = GameObject.Find("CurrentResources");
        if (resObj == null)
        {
            Debug.LogWarning("RES UI not found!! May be due to being disabled.");
        }
        else
        {
            currentResourcesUIController temp = resObj.GetComponent<currentResourcesUIController>();
            if (temp != null)
            {
                temp.updateResourcesUI();
            }
            else {
                Debug.LogError("Couldn't find resourceUI");
            }
        }
	}

	public static InBuilding GetInBuilding(){
		return getMetaObject().GetComponent<InBuilding>();
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

	/// <summary>
	/// Returns the TownCenter GameObject
	/// </summary>
	/// <returns></returns>
	public static GameObject getTownCenter(){
		if(tc == null){
			tc = GameObject.Find("TownCenter");
		}
		if(tc == null)
			Debug.LogError("Couldn't find TownCenter");
		
		return tc;
	}

	/// <summary>
	/// Returns the Player GameObject
	/// </summary>
	/// <returns></returns>
	public static GameObject getPlayer(){
		if(player == null){
			player = GameObject.FindWithTag("Player");
		}
		if(player == null)
			Debug.LogError("Couldn't find Player");
		
		return player;
	}
}
