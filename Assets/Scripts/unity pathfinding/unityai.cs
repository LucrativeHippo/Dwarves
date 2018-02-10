using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class unityai : MonoBehaviour
{
    public Transform destination;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<NavMeshAgent>().destination = destination.position;
    }
}
