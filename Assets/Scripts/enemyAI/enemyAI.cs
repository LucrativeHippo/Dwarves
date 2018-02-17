using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour {	
	public Transform destination;
	NavMeshAgent agentCtrl;
	Vector3 spawnPoint;
	public float threatRange =10f;


	// Use this for initialization
	void Start () {
		agentCtrl = this.GetComponent<NavMeshAgent>();
		spawnPoint = this.gameObject.transform.position;
		setDestination ();
//		gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
	}

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(agentCtrl.remainingDistance);
            if (agentCtrl.remainingDistance <= threatRange)
            {

                setDestination();
            }
            else
            {
                backToSpawn();
            }
        }



	private void setDestination(){
			if (destination != null) {
			Vector3 targetVector = destination.transform.position;
			agentCtrl.SetDestination (targetVector);
		}
	}

	private void backToSpawn(){
		
		Debug.Log (spawnPoint);
		agentCtrl.SetDestination (spawnPoint);
	}
}
