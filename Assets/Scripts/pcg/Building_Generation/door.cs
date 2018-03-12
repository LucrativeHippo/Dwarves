using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    GameObject player;
    Vector3Int pos;

    private Vector3 returnPoint;

    // Use this for initialization
    void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setReturn(int x, int y, int z)
    {
        
        pos = new Vector3Int(x,0,z);
    }

    public void recieveAction()
    {
        
        // if(pos != null)
        // {
            print(pos.x + "" + pos.y + "" + pos.z);
            player.SetActive(false);
            player.transform.position = pos;
            player.SetActive(true);
            //print(xpos + zpos);
        // }
        // else
        // {
            
        //     Debug.Log("The return building has not been set yet");
        // }
    }
}
