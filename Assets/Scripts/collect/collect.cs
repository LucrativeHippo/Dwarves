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
    public Health hp;
    //public float threatRange = 2f;

    public int resAmount = 0;
    int maxRes = 10;

    
    public bool getResource = false;
    public bool dropResource = false;
    public bool isfull = false;

    public ResourceTypes findingType = ResourceTypes.DIAMOND;

    public string getResourceName(ResourceTypes r){
        switch(r){
            case ResourceTypes.WOOD:
                return "wood";
            case ResourceTypes.DIAMOND:
                return "water";
            default:
                return "wood";
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
        hp = gameObject.GetComponent<Health>();
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
        if (getResource && !isfull)
        {
            updateLocations();
            moveToNearest(getResName());
        }


        if (dropResource && isfull)
        {
            updateLocations();
            moveToNearest(getResBuildName());
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
        if(this.isSelectedResource(other) && resAmount<maxRes && getResource){
            //hp = other.GetComponent<Health>();
            //other.SendMessage("damage");
            resAmount++;
            Debug.Log(getResName()+":"+resAmount);
            //hp.damage(1);

            //Debug.Log(hp.health);

            if(resAmount == maxRes){
                Debug.Log("MADE IT");
                isfull = true;
                getResource = false;
                dropResource = true;
            }
        }

        if(this.isSelectedResBuilding(other) && resAmount>0 && dropResource){
            resAmount--;
            Debug.Log(this.getResName()+":"+resAmount);
            MetaScript.getRes().addResource(this.findingType,1);

            if(resAmount == 0){
                print("RES: "+resAmount);
                isfull = false;
                getResource = true;
                dropResource = false;
            }
        }
    }
}
 


