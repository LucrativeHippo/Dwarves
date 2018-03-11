using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    private float meshSize = 80.0f;


    // Use this for initialization
    void Start()
    {
        townCentre = GameObject.FindGameObjectWithTag("TownCenter");
        if (townCentre != null)
        {
            
            travelDirection = (townCentre.transform.position - transform.position).normalized;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (townCentre == null)
        {
            townCentre = GameObject.FindGameObjectWithTag("TownCenter");
            if (townCentre != null)
            {

                travelDirection = (townCentre.transform.position - transform.position).normalized;
            }
        }
        if (onNavMesh())
        {
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            gameObject.GetComponent<enemyAI>().enabled = true;
            enabled = false;

        }
    }


    public bool onNavMesh()
    {
        float enemyx = transform.position.x;
        float enemyz = transform.position.z;
        float tcx = townCentre.transform.position.x;
        float tcz = townCentre.transform.position.z;
        if(enemyx > tcx - meshSize && enemyx < tcx + meshSize && enemyz > tcz - meshSize && enemyz < tcz + meshSize)
        {
            return true;
        }
        return false;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OwnedNPC"))
        {
            npcTargeted = true;
            travelDirection = (other.transform.position - transform.position).normalized;
            transform.position += travelDirection * speed * Time.deltaTime;
        }

    }
}
