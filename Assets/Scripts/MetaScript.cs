using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaScript : MonoBehaviour {
	//QuestResourceManager res;
	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<ResourceManager>().setFood(0);
		//gameObject.GetComponent<ResourceManager>().setSand(0);
		//gameObject.GetComponent<ResourceManager>().setWood(0);
        //res = MetaScript.getRes();

	}
	
	/// <summary>
	/// Static reference to location of this script
	/// </summary>
	/// <returns></returns>
	public static GameObject getMetaObject(){
		return GameObject.Find("Meta");
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
	public static OwnedNPCList GetNPC(){
		return getMetaObject().GetComponent<OwnedNPCList>();
	}
    public static outpost_controller getOPController()
    {
        return getMetaObject().GetComponent<outpost_controller>();
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
}
