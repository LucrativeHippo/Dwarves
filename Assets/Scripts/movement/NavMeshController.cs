using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour {
    // Bounds bounds;
    Vector3 deadZone = new Vector3(0.5f,0,0.5f);

	// Use this for initialization
	void Awake () {
        MetaScript.preTeleport();
    }

    void Start()
    {
        // getOffset();
        // outer = bounds;
        // inner = bounds;
        // outer.size += deadZone;
        // inner.size -= deadZone;
    }
    // Bounds inner;
    // Bounds outer;
    // private void getOffset(){
    //     bounds = MetaScript.getTownCenter().GetComponentInChildren<NavMeshBuildFunction>().GetBounds();
    // }

    private void setNav(bool t)
    {
        GetComponent<NavMeshAgent>().enabled = t;
    }

    ArrayList resList = new ArrayList();
	
	// Update is called once per frame
	void Update () {
        bool localMesh = true;
        foreach(NavMeshBuildFunction f in resList.ToArray()){
            if(f != null && inside(f.GetBounds(),true)){
                setNav(inside(f.GetBounds(),false));
                localMesh = false;
                break;
            }
        }
        GetComponent<LocalNavMeshBuilder>().enabled = localMesh;
        // if (closeToTC(false))
        // {
        //     setNav(true);
        //     GetComponent<LocalNavMeshBuilder>().enabled = false;
           
        // }else if(closeToTC(true)){
        //     setNav(false);
        // }
        // else
        // {
        //     GetComponent<LocalNavMeshBuilder>().enabled = true;
        //     setNav(true);
        // }
	}
    // public bool closeToTC(bool isInDeadZone)
    // {
    //     Bounds checkBounds = bounds;
    //     if(isInDeadZone){
    //         checkBounds.size += deadZone;
    //     }else{
    //         checkBounds.size -= deadZone;
    //     }
    //     return (checkBounds.Contains(transform.position)) ;
    // }

    private bool inside(Bounds b, bool outer){
        if(outer){
            b.size += deadZone;
        }else{
            b.size -= deadZone;
        }
        return (b.Contains(transform.position)) ;
    }

    public bool onNavMesh()
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(transform.position, out hit, 0.3f, NavMesh.AllAreas);
    }



    public void AddResMesh(NavMeshBuildFunction f){
        resList.Add(f);
    }
    public void RemResMesh(NavMeshBuildFunction f){
        resList.Remove(f);
    }
}
