﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSystem : MonoBehaviour, INPCListener {

    [SerializeField] private float foodUsedPerNPC;
    [SerializeField] private int damageForStarving;

    [SerializeField] private float starvingTickTimer = 10.0F;
    private float getNPCsTimerTime = 5.0f;

    private ResourceManager resourceManager;

    private GameObject allUIGameObjects;
    private GameObject npcManagerGameObject;

    private OwnedNPCList ownedNPC;


    [SerializeField] private bool noFood;

    void Start () {
        starvingTickTimer = GameObject.Find("Calendar").GetComponent<GameTime>().dayTime;
        resourceManager = MetaScript.getRes();
        allUIGameObjects = GameObject.Find ("AllUIObjectsCanvas");
        npcManagerGameObject = allUIGameObjects.transform.GetChild (0).GetChild (0).gameObject;
        
        setNPCList(MetaScript.GetNPC());

        noFood = false;
        
        StartCoroutine (starvingTimer (starvingTickTimer));
    }


    private void useFood () {
        float foodSaved = MetaScript.getGlobal_Stats().getFoodSaved();
        int currentFood = resourceManager.getResource (ResourceTypes.FOOD);
        float foodCost = ownedNPC.getCount() * foodUsedPerNPC - foodSaved;
        Debug.Log("Food used =" + foodCost);
        if(foodCost < 0)
        {
            foodCost = 0;
        }
        if(resourceManager.hasResource(ResourceTypes.FOOD,(int)foodCost)){
            resourceManager.addResource (ResourceTypes.FOOD, (int)-foodCost);
            noFood = false;
        } else {
            resourceManager.addResource (ResourceTypes.FOOD, -currentFood);
            noFood = true;
        }
    }

    IEnumerator starvingTimer (float waitForTime) {
        yield return new WaitForSeconds (waitForTime);
        Debug.Log("Starving tick");
        useFood();
        if (isThereNoFood ()) {
            starving ();
        }
        StartCoroutine (starvingTimer (waitForTime));
    }

    private void starving () {
        foreach (var aNPC in ownedNPC.getNPCs()) {
            aNPC.GetComponent<Health> ().damage (damageForStarving);
        }
    }

    public bool isThereNoFood () {
        return noFood;
    }


    public void setNPCList(OwnedNPCList list)
    {
        ownedNPC = list;
    }

    public void publish()
    {
        // do nothing for now?
    }
}
