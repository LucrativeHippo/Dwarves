using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlots : MonoBehaviour {
    

    private terrainGenerator tg;

    [SerializeField]
    private int upgradeLevel = 0;

    private GameObject tc;

    private bool notInstant = true;

    [SerializeField]
    private GameObject plot;
    [SerializeField]
    private GameObject buildingSign;

    private Dictionary<string, bool> added;


	// Use this for initialization
	void Start () {
        added = new Dictionary<string, bool>();
        tc = MetaScript.getTownCenter();
        //tg = GameObject.Find("Terrain Generator").GetComponent<terrainGenerator>();
        if (tc != null)
        {
            
            int tcx = (int)tc.transform.position.x;
            int tcz = (int)tc.transform.position.z;
            
            for (int i= -1; i < 2; i=i+2)
            {
                for (int j= -1; j < 2; j=j+2)
                {
                    
                   if(!added.ContainsKey((i * 2 + tcx) + " " + (j * upgradeLevel + tcz)))
                    {
                        print((i * 2 + tcx) + " " + (j * upgradeLevel + tcz));
                        Instantiate(plot, new Vector3(i * 2 + tcx, 0, j * upgradeLevel + tcz), Quaternion.identity);
                        Instantiate(buildingSign, new Vector3(i * 2 + tcx, 0, j * upgradeLevel + tcz), Quaternion.identity);
                        added[(i * 2 + tcx) + " " + (j * upgradeLevel + tcz)] = true;
                    }
                   
                    if (!added.ContainsKey((i * upgradeLevel + tcx) + " " + (j * 2 + tcz)))
                    {
                        print((i * upgradeLevel + tcx) + " " + (j * 2 + tcz));
                        Instantiate(plot, new Vector3(i * upgradeLevel + tcx, 0, j * 2 + tcz), Quaternion.identity);
                        Instantiate(buildingSign, new Vector3(i * upgradeLevel + tcx, 0, j * 2 + tcz), Quaternion.identity);
                        added[(i * upgradeLevel) + " " + (j * 2 + tcz)] = true;
                    }

                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
