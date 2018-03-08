using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    [SerializeField]
    private GameObject townCentre;
    [SerializeField]
    private GameObject NPC;
    [SerializeField]
    private int speed = 3;

    private Vector3 travelDirection;


	// Use this for initialization
	void Start () {
        townCentre = GameObject.FindGameObjectWithTag("TownCentre");
        if(townCentre != null)
        {
            print("hi2");
            travelDirection = (townCentre.transform.position - transform.position).normalized;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (townCentre == null)
        {
            townCentre = GameObject.FindGameObjectWithTag("TownCentre");
            if (townCentre != null)
            {
                print("hi");
                travelDirection = (townCentre.transform.position - transform.position).normalized;
            }
        }
        else {
            transform.position += travelDirection * speed * Time.deltaTime;
        }
    }
}
