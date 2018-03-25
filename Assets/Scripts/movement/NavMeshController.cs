using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour {
    Bounds bounds;
    Vector3 deadZone = new Vector3(0.5f,0,0.5f);

	// Use this for initialization
	void Awake () {
        MetaScript.preTeleport();
    }

    void Start()
    {
        getOffset();
    }
    private void getOffset(){
        bounds = MetaScript.getTownCenter().GetComponentInChildren<NavMeshBuildFunction>().GetBounds();
    }

    private void setNav(bool t)
    {
        GetComponent<NavMeshAgent>().enabled = t;
    }
	
	// Update is called once per frame
	void Update () {
        if (closeToTC(false))
        {
            setNav(true);
            GetComponent<LocalNavMeshBuilder>().enabled = false;
           
        }else if(closeToTC(true)){
            setNav(false);
        }
        else
        {
            GetComponent<LocalNavMeshBuilder>().enabled = true;
            setNav(true);
        }
	}
    public bool closeToTC(bool isInDeadZone)
    {
        Bounds checkBounds = bounds;
        if(isInDeadZone){
            checkBounds.size += deadZone;
        }else{
            checkBounds.size -= deadZone;
        }
        return (checkBounds.Contains(transform.position)) ;
    }

    public bool onNavMesh()
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(transform.position, out hit, 0.3f, NavMesh.AllAreas);
    }
}
