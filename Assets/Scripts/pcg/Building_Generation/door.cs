using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    GameObject player;
    private int xpos;
    private int ypos;
    private int zpos;

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
        print("setting return");
        xpos = x;
        ypos = y;
        zpos = z;
    }

    public void recieveAction()
    {
        
        if (!this.enabled)
            return;
        if(xpos != null && ypos != null && zpos != null)
        {
            player.transform.position = new Vector3(xpos, ypos, zpos);
        }
        else
        {
            
            Debug.Log("The return building has not been set yet");
        }
    }
}
