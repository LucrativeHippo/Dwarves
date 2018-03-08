using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour {	
	public Transform destination;
	NavMeshAgent agentCtrl;
	Vector3 spawnPoint;
	public float threatRange =10f;
	[SerializeField]
	public float damage=5f;
	[SerializeField]
	public float max_health =30f;
	[SerializeField]
	public float cur_health;
	[SerializeField]
	public float atkSpeed = 1.0f;



	// Use this for initialization
	void Start () {
		cur_health = max_health;
		agentCtrl = this.GetComponent<NavMeshAgent>();
		spawnPoint = this.gameObject.transform.position;
		setDestination ();
//		gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (cur_health <= 0)
			die ();
        //Debug.Log(agentCtrl.remainingDistance);
            if (agentCtrl.remainingDistance <= threatRange)
            {

                setDestination();
            }
            else
            {	//target too far away, retreat
                backToSpawn();
            }


       }


	void fixedUpdate(){
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

	void die(){
		Destroy (gameObject);
	}
}
