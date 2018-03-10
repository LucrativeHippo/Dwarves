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
        else if(!npcTargeted){
            transform.position += travelDirection * speed * Time.deltaTime;
        }
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
