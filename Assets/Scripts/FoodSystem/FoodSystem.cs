using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSystem : MonoBehaviour {

    [SerializeField] private int foodUsedPerNPC;

    private GameObject metaObject;

    private GameObject allUIGameObjects;
    private GameObject npcManagerGameObject;

    private NPCManager theNPCManager;

    private List<GameObject> theNPCs;

    private bool noFood;

    void Start () {
        metaObject = GameObject.Find ("Meta");
        allUIGameObjects = GameObject.Find ("AllUIObjectsCanvas");
        npcManagerGameObject = allUIGameObjects.transform.GetChild (0).GetChild (0).gameObject;

        theNPCManager = npcManagerGameObject.GetComponent<NPCManager> ();

        theNPCs = new List<GameObject> ();
        noFood = false;
        StartCoroutine (getNPCsTimer (5.0F));
    }

    private void setNPC () {
        theNPCs = theNPCManager.getNPCs ();
    }

    IEnumerator getNPCsTimer (float waitForTime) {
        yield return new WaitForSeconds (waitForTime);
        setNPC ();
        StartCoroutine (getNPCsTimer (waitForTime));
    }

    private void useFood () {
        int currentFood = metaObject.GetComponent<ResourceManager> ().getResource (ResourceTypes.FOOD);
        int foodCost = theNPCs.Count * foodUsedPerNPC;
        if (currentFood - foodCost > 0) {
            metaObject.GetComponent<ResourceManager> ().addResource (ResourceTypes.FOOD, -foodCost);
            noFood = false;
        } else {
            metaObject.GetComponent<ResourceManager> ().addResource (ResourceTypes.FOOD, -currentFood);
            noFood = true;
        }
    }

    public bool isThereNoFood () {
        return noFood;
    }

}
