using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class caveMovement : MonoBehaviour {

    [SerializeField]
    private GameObject townCentre;
    [SerializeField]
    private GameObject NPC;
    [SerializeField]
    private int speed = 3;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (onNavMesh())
        {
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            gameObject.GetComponent<enemyAI>().enabled = true;
            enabled = false;

        }
        
    }


    public bool onNavMesh()
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(transform.position, out hit, 0.3f, NavMesh.AllAreas);
    }


    void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag("OwnedNPC"))
        // {
        //     npcTargeted = true;
        //     travelDirection = (other.transform.position - transform.position).normalized;
        //     transform.position += travelDirection * speed * Time.deltaTime;
        // }

    }
}
