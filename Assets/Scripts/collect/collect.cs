using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class collect : MonoBehaviour
{
    private NavMeshAgent agent;
    //public Transform destinationforfull;
    //public Transform destinationforzero;
    private GameObject currentbuilding;
    private GameObject currentresource;
    //public float threatRange = 2f;

    public int resAmount = 0;
    int maxRes = 10;

    private enum npcState{
        asleep,
        getResource,
        dropResource
    }
    [SerializeField]
    private npcState state = npcState.asleep;
    public ResourceTypes findingType = ResourceTypes.WOOD;

    public void startCollecting(ResourceTypes t){
        // TODO: checks to make sure we have found this resource

        // TODO: Uncomment this once we have all buildings implemented
        // Checks also needed for building destruction
        // if(resAmount != 0 && findingType != t){
        //     state = npcState.dropResource;
        //     while(resAmount!=0){
        //         // do nothing until the drop off current resource
        //     }
        // }

        // after dropping resource 
        findingType = t;
        state = npcState.getResource;
    }

    public string getResourceName(ResourceTypes r){
        switch(r){
            case ResourceTypes.WOOD:
                return "tree";
            case ResourceTypes.DIAMOND:
                return "water";
            default:
                return "tree";
        }
    }
    private string getResName(){
        return getResourceName(findingType);
    }
    private string getResBuildName(){
        return getResName()+"building";
    }

    private bool isSelectedResource(Collider o){
        return o.CompareTag(getResName());
    }
    private bool isSelectedResBuilding(Collider o){
        return o.CompareTag(getResBuildName());
    }

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    private void updateLocations(){
        currentbuilding = GameObject.FindWithTag(getResBuildName());
        currentresource = GameObject.FindWithTag(getResName());
    }
    private void moveToNearest(string name){
            agent.SetDestination(FindClosestresourse(name).transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        switch(state){
            case npcState.dropResource:
                //updateLocations();
                if(resAmount==0)
                    state = npcState.getResource;
                moveToNearest(getResBuildName());
                break;

            case npcState.getResource:
                //updateLocations();
                if(resAmount == maxRes)
                    state = npcState.dropResource;
                moveToNearest(getResName());
                break;

            case npcState.asleep:
                break;
            default: break;

        }
    }




    GameObject FindClosestresourse(string resourcename)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(resourcename);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }





    GameObject FindClosestbuilding(string buildingname)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(buildingname);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }




    private void OnTriggerStay(Collider other)
    {
        if(this.isSelectedResource(other) && resAmount<maxRes && state == npcState.dropResource){
            //hp = other.GetComponent<Health>();
            //other.SendMessage("damage");
            resAmount++;
            Debug.Log(getResName()+":"+resAmount);
            //hp.damage(1);

            //Debug.Log(hp.health);

            if(resAmount == maxRes){
                updateLocations();
                state = npcState.getResource;
            }
        }

        if(this.isSelectedResBuilding(other) && resAmount>0 && state == npcState.dropResource){
            resAmount--;
            Debug.Log(this.getResName()+":"+resAmount);
            MetaScript.getRes().addResource(this.findingType,1);

            if(resAmount == 0){
                print("RES: "+resAmount);
                updateLocations();
                state = npcState.getResource;
            }
        }
    }
}
 


