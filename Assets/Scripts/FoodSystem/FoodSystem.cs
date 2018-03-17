using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSystem : MonoBehaviour {

    [SerializeField] private int foodUsedPerNPC;
    [SerializeField] private int damageForStarving;

    [SerializeField] private float starvingTickTimer = 10.0F;
    private float getNPCsTimerTime = 5.0f;

    private GameObject metaObject;

    private GameObject allUIGameObjects;
    private GameObject npcManagerGameObject;

    private NPCManager theNPCManager;

    private List<GameObject> theNPCs;

    [SerializeField] private bool noFood;

    void Start () {
        metaObject = GameObject.Find ("Meta");
        allUIGameObjects = GameObject.Find ("AllUIObjectsCanvas");
        npcManagerGameObject = allUIGameObjects.transform.GetChild (0).GetChild (0).gameObject;

        theNPCManager = npcManagerGameObject.GetComponent<NPCManager> ();

        theNPCs = new List<GameObject> ();
        noFood = false;
        StartCoroutine (getNPCsTimer (getNPCsTimerTime));
        StartCoroutine (starvingTimer (starvingTickTimer));
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

    IEnumerator starvingTimer (float waitForTime) {
        yield return new WaitForSeconds (waitForTime);
        if (isThereNoFood ()) {
            starving ();
        }
        StartCoroutine (starvingTimer (waitForTime));
    }

    private void starving () {
        foreach (var aNPC in theNPCs) {
            aNPC.GetComponent<Health> ().damage (damageForStarving);
        }
    }

    public bool isThereNoFood () {
        return noFood;
    }

}
