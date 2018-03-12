using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

    private GameObject target;
    private UnityEngine.AI.NavMeshAgent navComponent;
    // the distance in which to follow the player
    [SerializeField]
    private float followDistance;

    private GameObject tc;

    void Awake()
    {
        navComponent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }
    // Use this for initialization
    void Start () {
        
        target = GameObject.FindWithTag("Player");
        navComponent = this.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        


    }
	
	// Update is called once per frame
	void Update () {
        if(target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
        
        if (target != null)
        {
            
            navComponent.enabled = true;
            navComponent.SetDestination(target.transform.position);
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            
            if (distanceToTarget <= followDistance)
            {
                
                navComponent.isStopped = true;
                navComponent.SetDestination(target.transform.position);
                
            }
            else {
                navComponent.isStopped = false;
                
            }
        }
    }
}
