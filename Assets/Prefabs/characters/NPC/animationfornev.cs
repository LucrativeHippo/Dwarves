using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animationfornev : MonoBehaviour {
    public Transform target;
    private Animator anim;
    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(agent.velocity);
        if(agent.velocity.x==0f){

            anim.SetInteger("Direction",0);
        }
        if(agent.velocity.z>.01f){
            anim.SetInteger("Direction",2);
        }
        if (agent.velocity.z < -.01f)
        {
            anim.SetInteger("Direction", 1);
        }
        if (agent.velocity.x > .01f )
        {
            anim.SetInteger("Direction", 3);
        }
       if (agent.velocity.x < -.01f)
        {
            anim.SetInteger("Direction", 4);
        }
     
   
 
 
	}
   
}
