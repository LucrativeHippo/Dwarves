using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject townCentre;
    [SerializeField]
    private GameObject NPC;
    [SerializeField]
    private int speed = 3;

    private bool npcTargeted = false;

    private Vector3 travelDirection;

    public void getDirection(){
        townCentre = GameObject.FindGameObjectWithTag("TownCenter");
        if (townCentre != null){
            travelDirection = (townCentre.transform.position - transform.position).normalized;
        }
    }

    // Use this for initialization
    void Start()
    {
        getDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (townCentre == null)
        {
            getDirection();
        }
        if (onNavMesh())
        {
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            gameObject.GetComponent<enemyAI>().enabled = true;
            enabled = false;

        }
        transform.position+= travelDirection * speed * Time.deltaTime;
    }


    public bool onNavMesh()
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(transform.position,out hit, 0.3f, NavMesh.AllAreas);
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
