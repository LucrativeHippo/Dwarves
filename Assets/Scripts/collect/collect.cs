using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class collect : MonoBehaviour
{
    private NavMeshAgent agent;
    //public Transform destinationforfull;
    //public Transform destinationforzero;
    public GameObject currentbuilding;
    public GameObject currentresource;
    //public float threatRange = 2f;

    public int curRes = 0;
    public int maxRes;
    public float pickupTime;

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

        // TODO: check this npc stats change multipliers
        pickupTime = 2f;
        maxRes = 10;

        updateLocations();
        agent.enabled = true;
        agent.isStopped = false;
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
    private bool isFull(){return curRes == maxRes;}
    private bool isEmpty(){return curRes == 0;}

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    private void updateLocations(){
        findBuilding();
        findResource();
    }
    private bool emptyResource(){
        return currentresource == null;
    }
    private bool emptyBuilding(){
        return currentbuilding == null;
    }

    private void findBuilding(){
        currentbuilding = findClosestTag(getResBuildName(),gameObject);
    }
    private void findResource(){
        findResource(currentbuilding);
    }
    private void findResource(GameObject g){
        currentresource = findClosestTag(getResName(), g);
    }
    private void moveTo(GameObject g){
        agent.isStopped = false;
        if(!agent.SetDestination(g.transform.position)){
            Vector3 temp = g.transform.position - transform.position;
            if(!agent.SetDestination(temp.normalized * 5 + gameObject.transform.position)){
                Debug.LogError("Failed to take a step");
            }
        }
    }
    IEnumerator move(){
        idle = false;
        
        yield return new WaitForSeconds (4);
        idle = true;
    }
    private bool idle = true;

    private void moveSteps(GameObject g){
        if(idle){
            moveTo(g);
            StartCoroutine(move());
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(emptyBuilding() || emptyResource()){
            updateLocations();
        }
        switch(state){
            case npcState.gotoBuilding:
            moveSteps(currentbuilding);
                break;

            case npcState.gotoResource:
            moveSteps(currentresource);
                break;
            
            case npcState.dropRes:

                if(isEmpty()){
                    state = npcState.gotoResource;
                }else if(emptyBuilding()){
                    findBuilding();
                    state = npcState.gotoBuilding;
                }
                break;
            
            case npcState.gatherRes:
                if(isFull()){
                    state = npcState.gotoBuilding;
                }else if(currentresource == null){
                    findResource(gameObject);
                    updateLocations();
                }
                break;


            case npcState.asleep:
                //agent.isStopped = true;
                break;
            default: break;

        }
    }



    
    GameObject findClosestTag(string name, GameObject from)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(name);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = from.transform.position;
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
        if(ready){
        if(this.isSelectedResource(other)){
            // Change state from going to res to gathering
            if(state == npcState.gotoResource){
                state = npcState.gatherRes;
            }else if(state == npcState.gatherRes){
                if(isFull()){
                    state = npcState.gotoBuilding;
                }else{
                // Keep gathering
                    if(ready){
                        StartCoroutine(doJob());
                    }
                }
            }
        }

        if(this.isSelectedResBuilding(other)){
            if(state == npcState.gotoBuilding){
                state = npcState.dropRes;
            }else if(state == npcState.dropRes){
                if(isEmpty()){
                    state = npcState.gotoResource;
                }else{
                    if(ready){
                        drop();
                    }
                }
            }
        }
        }
    }
    private bool ready = true;

    IEnumerator doJob(){
        ready = false;
        if(currentresource==null){
            state = npcState.gotoResource;
            yield return null;
        }else{
            gather();
            yield return new WaitForSeconds (pickupTime);
        }
        ready = true;
    }
    private void gather(){
        Health t = currentresource.GetComponent<Health>();
        if(t!=null){
            t.damage(1);
        }
        curRes++;
    }

    private void drop(){
        MetaScript.getRes().addResource(this.findingType,curRes);
        curRes = 0;
    }
}
 


