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
        Debug.Log(agent.velocity);
        if(agent.velocity.x==0 && agent.velocity.z==0){

            anim.SetInteger("Direction",0);
        }
        else  if(agent.velocity.z>.2f){
            anim.SetInteger("Direction",1);
        }
        else if (agent.velocity.z < -.2f)
        {
            anim.SetInteger("Direction", 2);
        }
        else if (agent.velocity.x > .2f)
        {
            anim.SetInteger("Direction", 3);
        }
        else if (agent.velocity.x <0 && agent.velocity.z<0)
        {
            anim.SetInteger("Direction", 4);
        }
        else if (agent.velocity.x > 0 && agent.velocity.z > 0)
        {
            anim.SetInteger("Direction", 3);
        }
	}
   
}
