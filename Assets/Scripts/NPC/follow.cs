using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

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
        
        navComponent = this.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 tPos = MetaScript.getPlayer().transform.position;
        Vector3 pPos = transform.position;
        navComponent.enabled = true;
        //navComponent.SetDestination(target.transform.position);
        float distanceToTarget = Vector3.SqrMagnitude(tPos- pPos);
        
        if (distanceToTarget <= Mathf.Pow(followDistance,2))
        {
            
            navComponent.isStopped = true;
            
        }else if(distanceToTarget >= Mathf.Pow(maxDist,2)){
            navComponent.enabled = false;
            Vector3 updatePos = (pPos - tPos).normalized*maxDist+tPos;
            updatePos.y = tPos.y;
            transform.position = updatePos;
            navComponent.enabled = true;
        }else {
            navComponent.isStopped = false;
            navComponent.SetDestination(tPos);
            
        }
    }
    public float maxDist = 5f;
}
