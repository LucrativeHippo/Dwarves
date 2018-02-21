using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class collect : MonoBehaviour {
    private NavMeshAgent agent;
    public Transform destinationforfull;
    public Transform destinationforzero;
    public static int wateramount = 0;

	// Use this for initialization
	void Start () {
       
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "water"&&wateramount<200)
        {
            

                wateramount += 1;
                Debug.Log("water:" + wateramount);

                if (wateramount == 200)
                {

                agent.SetDestination((destinationforfull.position));

                }

        }
        if (other.tag == "waterbuilding"&&wateramount>0)
        {
            wateramount -= 1;
            Debug.Log("water:" + wateramount);
            if (wateramount == 0)
            {

                agent.SetDestination((destinationforzero.position));

            }

        }


    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Destroy(other.gameObject);  
    //}
 

}
