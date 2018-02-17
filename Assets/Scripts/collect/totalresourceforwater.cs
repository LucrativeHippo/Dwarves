using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
public class totalresourceforwater : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destinations;
    public static int totalwateramount = 0;

    // Use this for initialization
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "collecter"&&totalwateramount<200)
        {
            
            totalwateramount += 1;
            Debug.Log("total amount in waterbuilding:" + totalwateramount);
            if (totalwateramount == 200)
            {

                //agent.SetDestination((destinations.position));
                Debug.Log("full" );
                Debug.Log(totalwateramount);
            }
        }
    }

   

}

