using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour {
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject floor;
    [SerializeField]
    private GameObject door;

    private int xpos;
    private int ypos;
    private int zpos;

    private building_generator bg;


	// Use this for initialization
	void Start () {
        bg = new building_generator((int)gameObject.transform.position.x, (int)gameObject.transform.position.y, (int)gameObject.transform.position.z, gameObject, wall, door, floor);
        print(bg.getdoorxlocation());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
