using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
public class where : MonoBehaviour {
    private NavMeshAgent agent;
    public Transform destinations;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination((destinations.position));
	}
}
