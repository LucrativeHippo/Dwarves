using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class unityaifor2D : MonoBehaviour {
    public Transform target;
    public float zoff;
    public float xoff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.rotation.x = 90;
        //transform.GetComponent<NavMeshAgent>().destination = new Vector3(target.localPosition.x, transform.localPosition.y, target.localPosition.z + zoff);

	}


    private void LateUpdate()
    {
        transform.localPosition = new Vector3(target.localPosition.x+xoff, transform.localPosition.y, target.localPosition.z+zoff); 
    }
}
