using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outpost_controller : MonoBehaviour {

    private List<GameObject> outpostList;
    [SerializeField]
    private int maxOutPosts = 3;

    private int numOutposts = 0;

    private float minDistance;

	// Use this for initialization
	void Start () {
        outpostList = new List<GameObject>();

	}
	public void addOutpost()
    {
        numOutposts++;
    }

    public void destroyOutpost()
    {
        numOutposts--;
    }

    public bool canAddOutPost()
    {
        if(numOutposts < maxOutPosts)
        {
            return true;
        }
        return false;
        
    }

    public bool checkDistance(Vector3 position)
    {
        GameObject[] resArray = GameObject.FindGameObjectsWithTag("resBuilding");
        foreach(GameObject rb in resArray)
        {
            if (rb.GetComponentInChildren<NavMeshBuildFunction>().willOutpostIntersect(position))
            {
                return false;
            }
            
        }
        return true;
    }
}
