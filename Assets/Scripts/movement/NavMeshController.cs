using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour {
    GameObject tc;
    public Vector3 offset;

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
        tc = GameObject.FindGameObjectWithTag("TownCenter");
        offset = tc.GetComponent<NavMeshBuildFunction>().m_Size/2;
    }

    private void setNav(bool t)
    {
        GetComponent<NavMeshAgent>().enabled = t;
    }
	
	// Update is called once per frame
	void Update () {
        if(tc == null)
        {
            getOffset();
            print("Needed update");
        }
        if (closeToTC(false))
        {
            setNav(true);
            GetComponent<LocalNavMeshBuilder>().enabled = false;
            print("TC");
           
        }else if(closeToTC(true)){
            setNav(false);
            print("DEAD");
        }
        else
        {
            GetComponent<LocalNavMeshBuilder>().enabled = true;
            setNav(true);
            print("OUT");
        }
	}
    public bool closeToTC(bool isInDeadZone)
    {
        Vector3 deadZone = new Vector3(0.5f,0,0.5f);
        if(isInDeadZone){
            deadZone *= -1;
        }
        return (lessThan(transform.position, tc.transform.position + new Vector3(-2f,0,-2f) + offset - deadZone) && greaterThan(transform.position, tc.transform.position-new Vector3(-2f,0,-2f) - offset + deadZone)) ;
        //return !GetComponent<LocalNavMeshBuilder>().enabled && onNavMesh();
    }

    private bool lessThan(Vector3 a, Vector3 b)
    {
        return a.x < b.x && a.z < b.z;
    }
    private bool greaterThan(Vector3 a, Vector3 b)
    {
        return a.x > b.x && a.z > b.z;
    }

    public bool onNavMesh()
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(transform.position, out hit, 0.3f, NavMesh.AllAreas);
    }
}
