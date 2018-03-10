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
        gotoResource,
        gotoBuilding,
        gatherRes,
        dropRes
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
        state = npcState.gotoResource;
    }

    public string getResourceName(ResourceTypes r){
        switch(r){
            case ResourceTypes.WOOD:
                return "tree";
            case ResourceTypes.DIAMOND:
                return "diamond";
            default:
                return "tree";
        }
    }
    private string getResName(){
        return getResourceName(findingType);
    }
    private string getResBuildName(){
        return "resBuilding";//return getResName()+"building";
    }

    private bool isSelectedResource(Collider o){
        return o.CompareTag(getResName());
    }
    private bool isSelectedResBuilding(Collider o){
        return o.CompareTag(getResBuildName());
    }
    private bool isFull(){return resAmount == maxRes;}
    private bool isEmpty(){return resAmount == 0;}

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
            agent.SetDestination(findClosestTag(name).transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        switch(state){
            case npcState.gotoBuilding:
                //updateLocations();
                moveToNearest(getResBuildName());
                break;

            case npcState.gotoResource:
                //updateLocations();
                moveToNearest(getResName());
                break;
            
            case npcState.dropRes:
                if(isEmpty()){
                    state = npcState.gotoResource;
                }
                break;
            
            case npcState.gatherRes:
                if(isFull()){
                    state = npcState.gotoBuilding;
                }
                break;


            case npcState.asleep:
                break;
            default: break;

        }
    }




    GameObject findClosestTag(string name)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(name);
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
        if(this.isSelectedResource(other)){
            // Change state from going to res to gathering
            if(state == npcState.gotoResource){
                state = npcState.gatherRes;
            }else if(state == npcState.gatherRes){
                if(isFull()){
                    updateLocations();
                    state = npcState.gotoBuilding;
                }else{
                // Keep gathering
                    resAmount++;
                }
            }
        }

        if(this.isSelectedResBuilding(other)){
            if(state == npcState.gotoBuilding){
                state = npcState.dropRes;
            }else if(state == npcState.dropRes){
                if(isEmpty()){
                    updateLocations();
                    state = npcState.gotoResource;
                }else{
                    resAmount--;
                    MetaScript.getRes().addResource(this.findingType,1);
                }
            }
        }
    }
}
 


