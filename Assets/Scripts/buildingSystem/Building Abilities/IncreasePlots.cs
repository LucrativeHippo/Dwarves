using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlots : MonoBehaviour {
    

    private terrainGenerator tg;

    [SerializeField]
    private int upgradeLevel = 0;

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
            
            for (int i= -1; i < 2; i=i+2)
            {
                for (int j= -1; j < 2; j=j+2)
                {
                       
                    Instantiate(plot, new Vector3(i*2+tcx,0,j*upgradeLevel+tcz), Quaternion.identity);
                    Instantiate(buildingSign, new Vector3(i*2+tcx, 0, j*upgradeLevel+tcz), Quaternion.identity);

                    Instantiate(plot, new Vector3(i * upgradeLevel + tcx, 0, j * 2 + tcz), Quaternion.identity);
                    Instantiate(buildingSign, new Vector3(i * upgradeLevel + tcx, 0, j * 2 + tcz), Quaternion.identity);

                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
