using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour {
    GameObject tc;
    public float tempOffset;

	// Use this for initialization
	void Awake () {

        gameObject.GetComponent<LocalNavMeshBuilder>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }

    void Start()
    {
        tc = GameObject.FindGameObjectWithTag("TownCenter");
        
    }

    private void setNav(bool t)
    {
        GetComponent<LocalNavMeshBuilder>().enabled = t;
        GetComponent<NavMeshAgent>().enabled = t;
    }
	
	// Update is called once per frame
	void Update () {
        if(tc == null)
        {
            tc = GameObject.FindGameObjectWithTag("TownCenter");
        }
        if (closeToTC())
        {
            setNav(false);
           
        }
        else
        {
            setNav(true);
        }
	}

    public bool closeToTC()
    {
        Vector3 offset = tc.GetComponent<NavMeshBuildFunction>().m_Size / 2;
        offset.x += tempOffset;
        offset.y += tempOffset;
        return (lessThan(transform.position, tc.transform.position + offset) && greaterThan(transform.position, tc.transform.position - offset)) ;
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
