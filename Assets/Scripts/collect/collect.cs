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
    [SerializeField]
    private int curRes = 0;
    public int maxRes = 10;
    public float pickupTime = 2.0f;

    [SerializeField]
    private npcState state = npcState.asleep;
    [SerializeField]
    ResourceTypes findingType = ResourceTypes.WOOD;

    public string getFindingType(){
        return findingType.ToString();
    }

    private float getRateStat(){ 
        switch (findingType){
            case ResourceTypes.COAL:
                return GetComponent<Skills>().getValue(Skills.list.strength);
            case ResourceTypes.GOLD:
                return GetComponent<Skills>().getValue(Skills.list.strength);
            case ResourceTypes.IRON:
                return GetComponent<Skills>().getValue(Skills.list.strength);
            case ResourceTypes.DIAMOND:
                return GetComponent<Skills>().getValue(Skills.list.strength);
            case ResourceTypes.STONE:
                return GetComponent<Skills>().getValue(Skills.list.strength);
            case ResourceTypes.FOOD:
                return GetComponent<Skills>().getValue(Skills.list.charisma);
            case ResourceTypes.WOOD:
                return GetComponent<Skills>().getValue(Skills.list.motivation);
            default:
                return 2f;
        }
    }

    private float getCapStat(){
        switch (findingType)
        {
            case ResourceTypes.COAL:
                return GetComponent<Skills>().getValue(Skills.list.motivation);
            case ResourceTypes.GOLD:
                return GetComponent<Skills>().getValue(Skills.list.motivation);
            case ResourceTypes.IRON:
                return GetComponent<Skills>().getValue(Skills.list.motivation);
            case ResourceTypes.DIAMOND:
                return GetComponent<Skills>().getValue(Skills.list.motivation);
            case ResourceTypes.STONE:
                return GetComponent<Skills>().getValue(Skills.list.motivation);
            case ResourceTypes.FOOD:
                return GetComponent<Skills>().getValue(Skills.list.braveness);
            case ResourceTypes.WOOD:
                return GetComponent<Skills>().getValue(Skills.list.strength);
            default:
                return 10f;
        }
    }

    private void setSkills(){
        maxRes = 10 + (int)getCapStat() - 5;
        pickupTime = 2f - (getRateStat() - 5f) / 5f;
    }
    
    public void startCollecting(ResourceTypes t){

        // after dropping resource 
        findingType = t;


        curRes = 0;

        Debug.Log("startCollecting");
        string s = getFindingType();
        findBuilding();
        Debug.Log(s);
        //updateLocations();
        setSkills();
        agent.enabled = true;
        agent.isStopped = false;
        state = npcState.gotoResource;
        findResource();
        if(currentresource== null){
            agent.SetDestination(gameObject.transform.position);
        }
    }


    public string getResourceName(ResourceTypes r){
        switch(r){
            case ResourceTypes.WOOD:
                return "tree";
            case ResourceTypes.DIAMOND:
                return "Diamond";
            case ResourceTypes.COAL:
                return "coal";
            case ResourceTypes.FOOD:
                return "food";
            case ResourceTypes.GOLD:
                return "gold";
            case ResourceTypes.IRON:
                return "iron";
            case ResourceTypes.STONE:
                return "stone";
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
        //this.getRateStat("gold");
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
        GameObject[] gos = GameObject.FindGameObjectsWithTag(getResBuildName());
        currentbuilding = null;
        foreach (GameObject go in gos)
        {
            if(go.activeInHierarchy){
                NavMeshBuildFunction f = go.GetComponent<NavMeshBuildFunction>();
                if(f!= null && f.GetBounds().Contains(gameObject.transform.position)){
                    currentbuilding= go;
                    return;
                }
            }
        }
        Debug.LogError("COULDN't FIND A BUILDING ");
    }
    private void findResource(){
        if(currentresource!=null)
            currentresource.GetComponent<MaxCollectors>().remove();


        if(currentbuilding == null){
            Debug.Log("A: current building wasn't assigned for some reason, searching again");
            // currentbuilding = findClosestTag(getResBuildName(),gameObject);
            findBuilding();
        }
        currentresource = findClosestResTagFromResBuilding();
        
        // if(currentresource == null){
        //     currentresource = findClosestTag(getResName(), gameObject);
        //     Debug.LogWarning("No resource buildings found, using my location as search point.");
        // }
        
        if(currentresource != null)
            currentresource.GetComponent<MaxCollectors>().add();
    }
    
    private void moveTo(GameObject g){
        agent.isStopped = false;

        if(g == null || !agent.SetDestination(g.transform.position)){
                Debug.LogWarning("Failed to go to resource. May be out of NavMesh bounds");
                // stop moving
                agent.SetDestination(gameObject.transform.position);
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
                    //findResource();
                    updateLocations();
                }
                break;


            case npcState.asleep:
                //agent.isStopped = true;
                break;
            default: break;

        }
    }



    public static GameObject findClosestTag(string name, GameObject from, float maxDist){
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(name);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = from.transform.position;
        foreach (GameObject go in gos)
        {
            NavMeshPath tempPath = new NavMeshPath();
            if(go.activeInHierarchy && onNavMesh(go.transform.position) && NavMesh.CalculatePath(position,go.transform.position,NavMesh.AllAreas, tempPath)){
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance && curDistance < maxDist*maxDist)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }
        return closest;
    }
    public static GameObject findClosestTag(string name, GameObject from)
    {
        return findClosestTag(name,from,Mathf.Infinity);
    }

    private GameObject findClosestResTagFromResBuilding(){
        GameObject [] gos = GameObject.FindGameObjectsWithTag(getResName());
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 pos = gameObject.transform.position;
        if(currentbuilding==null){
            Debug.LogError("ResBuilding value of null");
            return null;
        }
        Bounds bound = currentbuilding.GetComponentInChildren<NavMeshBuildFunction>().GetBounds();


        foreach(GameObject g in gos){
            float dist = (g.transform.position - pos).sqrMagnitude;
            
            //NavMeshPath tempPath = new NavMeshPath();
            if(dist < distance && g.activeInHierarchy && bound.Contains(g.transform.transform.position)
             && g.GetComponent<MaxCollectors>().hasRoom()){//} && 
            //onNavMesh(g.transform.position) && NavMesh.CalculatePath(pos,g.transform.position,NavMesh.AllAreas, tempPath)){
                closest = g;
                distance = dist;
            }
        }

        return closest;
    }

    

    public static bool onNavMesh(Vector3 position) {
        NavMeshHit hit;
        return NavMesh.SamplePosition(position,out hit, 0.3f, NavMesh.AllAreas);
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
        float resMult = MetaScript.getGlobal_Stats().getGatherMultiplier();
        curRes = (int) ((float) curRes * resMult);
        MetaScript.getRes().addResource(this.findingType,curRes);
        curRes = 0;
    }
    private npcState prevState = npcState.asleep;
	private void OnValidate()
	{
        if(prevState != state){
            startCollecting(findingType);
            prevState = state;
        }
	}
}
 


