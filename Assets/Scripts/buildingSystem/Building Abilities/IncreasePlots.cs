using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlots : MonoBehaviour {
    [SerializeField]
    private int sizeIncrease;

    private terrainGenerator tg;

    private GameObject tc;


    [SerializeField]
    private GameObject plot;
    [SerializeField]
    private GameObject buildingSign;


	// Use this for initialization
	void Start () {
        tc = GameObject.FindGameObjectWithTag("TownCenter");
        
        if (tc != null)
        {
            
            int tcx = (int)tc.transform.position.x;
            int tcz = (int)tc.transform.position.z;
            
            for (int i=(tcx - sizeIncrease); i < tcx + sizeIncrease + 1; i++)
            {
                for (int j= (tcz - sizeIncrease); j < tcz + sizeIncrease + 1; j++)
                {
                    if(i == (tcx - sizeIncrease) || j == (tcz - sizeIncrease) || j == tcz + sizeIncrease || i == tcx + sizeIncrease)
                    {
                       
                        Instantiate(plot, new Vector3(i,0,j), Quaternion.identity);
                        Instantiate(buildingSign, new Vector3(i, 0, j), Quaternion.identity);
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
