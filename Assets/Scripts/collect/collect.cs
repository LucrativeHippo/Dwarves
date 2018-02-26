using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class collect : MonoBehaviour
{
    private NavMeshAgent agent;
    //public Transform destinationforfull;
    //public Transform destinationforzero;
    public int wateramount;
    public int treeamount;
    private totalresourceforwater waterbuildings;
    private totalresourcefortree treebuildings;
    private ResourceManager manager;
    private GameObject currentbuilding;
    private GameObject currentresource;
    private destroyresourse hp;
    //public float threatRange = 2f;
    public bool gogetwater = false;
    public bool gogettree = false;
    public  bool isfull = false;
    // Use this for initialization
    void Awake()
    {
        //manager = gameObject.GetComponent<ResourceManager>();
        //currentresource = GameObject.FindWithTag("water");
        agent = GetComponent<NavMeshAgent>();
       
      
    }
    private void Start()
    {
        
        //hp = currentresource.GetComponent<destroyresourse>();
        //agent.SetDestination(FindClosestresourse().transform.position); 
    }

    // Update is called once per frame
    void Update()
    {
        if (gogetwater == true && gogettree == false && isfull == false)
        {
            currentbuilding=GameObject.FindWithTag("waterbuilding");
            currentresource = GameObject.FindWithTag("water");
           
            agent.SetDestination(FindClosestresourse("water").transform.position);

        }
        if (gogetwater == true && gogettree == false && isfull == true)
        {
            currentbuilding = GameObject.FindWithTag("waterbuilding");
            currentresource = GameObject.FindWithTag("water");
    
            agent.SetDestination(FindClosestbuilding("waterbuilding").transform.position);


        }



         if (gogettree == true && gogetwater == false && isfull==false)
        {
            
            currentbuilding = GameObject.FindWithTag("treebuilding");
            currentresource = GameObject.FindWithTag("tree");
           
            agent.SetDestination(FindClosestresourse("tree").transform.position); 
        } 

        if (gogettree == true && gogetwater == false && isfull==true)
        {
            currentbuilding = GameObject.FindWithTag("treebuilding");
            currentresource = GameObject.FindWithTag("tree");
            agent.SetDestination(FindClosestbuilding("treebuilding").transform.position); 
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




    public int getwateramount()
    {
        return wateramount;

    }
    public void setwateramount(int value)
    {
        wateramount = value;
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "water" && wateramount < 200 && gogetwater==true)
        {

            hp = other.GetComponent<destroyresourse>();
            wateramount += 1;
            Debug.Log("water:" + wateramount);
            hp.HP -= 1;
         
            Debug.Log(hp.HP);
        
            if (wateramount == 200 && treeamount==0)
            {
                isfull = true;
               // agent.SetDestination((FindClosestbuilding("waterbuilding").transform.position));

            }

        }
        if (other.tag == "waterbuilding" && wateramount>0 && gogetwater==true)
        {
            manager = other.GetComponent<ResourceManager>();
            waterbuildings = other.GetComponent<totalresourceforwater>();

            wateramount -= 1;
            Debug.Log("water:" + wateramount);
            waterbuildings.totalwateramount += 1;


            manager.addResource(ResourceTypes.DIAMOND, waterbuildings.totalwateramount);
         
            // send message to add water

            if (wateramount == 0 && treeamount==0)
            {
                isfull = false;
                //agent.SetDestination((FindClosestresourse("water").transform.position));

            }

        }

        if (other.tag == "tree" && treeamount < 200 && gogettree == true)
        {

            hp = other.GetComponent<destroyresourse>();
            treeamount += 1;
            Debug.Log("tree:" + treeamount);
            hp.HP -= 1;

            Debug.Log(hp.HP);
            if (treeamount == 200 && wateramount==0)
            {
                isfull = true;
                //agent.SetDestination((FindClosestbuilding("treebuilding").transform.position));

            }

        }




        if (other.tag == "treebuilding" && treeamount > 0 && gogettree == true)
        {
            treebuildings = other.GetComponent<totalresourcefortree>();
            treeamount -= 1;
            Debug.Log("tree:" + treeamount);
            treebuildings.totaltreeamount += 1;
            manager.addResource(ResourceTypes.WOOD, waterbuildings.totalwateramount);
            if (treeamount == 0 && wateramount==0)
            {
                isfull = false;
                //agent.SetDestination((FindClosestresourse("tree").transform.position));

            }

        }


    }
  
}
 


