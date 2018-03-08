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
	public int damage=5;
	[SerializeField]
	public float max_health =30f;
	[SerializeField]
	public float cur_health = 30f;
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

        //Debug.Log(agentCtrl.remainingDistance);
            if (agentCtrl.remainingDistance <= threatRange)
            {

                setDestination();
            }
            else
            {	//target too far away, retreat
                backToSpawn();
            }

		if (cur_health <= 0) {
			die ();
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

	private void die(){
		Destroy (gameObject);
	}
}
