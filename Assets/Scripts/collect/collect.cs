using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class collect : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destinationforfull;
    public Transform destinationforzero;
    public int wateramount;
    public totalresourceforwater waterbuildings;
    private GameObject currentwaterbuilding;
    public destroyresourse hp;
    public float threatRange = 2f;
  
    // Use this for initialization
    void Awake()
    {
        currentwaterbuilding = GameObject.FindWithTag("water");
        agent = GetComponent<NavMeshAgent>();
       
      
    }
    private void Start()
    {
        
        hp = currentwaterbuilding.GetComponent<destroyresourse>();
        agent.SetDestination(FindClosestresourse().transform.position); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }




    GameObject FindClosestresourse()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("water");
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





    GameObject FindClosestbuilding()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("waterbuilding");
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
        
        if (other.tag == "water" && wateramount < 200 )
        {

            hp = other.GetComponent<destroyresourse>();
            wateramount += 1;
            Debug.Log("water:" + wateramount);
            hp.waterHP -= 1;
         
            Debug.Log(hp.waterHP);
            if (wateramount == 200 )
            {
                agent.SetDestination((FindClosestbuilding().transform.position));

            }

        }
        if (other.tag == "waterbuilding" && wateramount>0)
        {
            wateramount -= 1;
            Debug.Log("water:" + wateramount);
            waterbuildings.totalwateramount += 1;
            if (wateramount == 0)
            {

                agent.SetDestination((FindClosestresourse().transform.position));

            }

        }


    }
  
}
 


