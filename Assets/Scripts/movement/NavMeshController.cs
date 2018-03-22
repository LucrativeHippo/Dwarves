using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour {
    GameObject center;
    Bounds bounds;
    Vector3 deadZone = new Vector3(0.5f,0,0.5f);

	// Use this for initialization
	void Awake () {

        gameObject.GetComponent<LocalNavMeshBuilder>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }

    void Start()
    {
        getOffset();
    }
    private void getOffset(){
        center = GameObject.Find("Campfire(Clone)");
        bounds = center.GetComponentInChildren<NavMeshBuildFunction>().GetBounds();
    }

    private void setNav(bool t)
    {
        GetComponent<NavMeshAgent>().enabled = t;
    }
	
	// Update is called once per frame
	void Update () {
        if(center == null)
        {
            getOffset();
            print("Needed update");
        }
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
