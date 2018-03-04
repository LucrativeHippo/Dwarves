using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour, IActionable {
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private GameObject floor;
    [SerializeField]
    private GameObject door;

    GameObject player;

    private int xpos;
    private int ypos;
    private int zpos;

    private building_generator bg;


    public void recieveAction()
    {
        print("hi");
        if (!this.enabled)
            return;

        player.transform.position = new Vector3(bg.getdoorxlocation(), bg.getylocation(), bg.getdoorzlocation());
    }

    // Use this for initialization
    void Start () {
        bg = new building_generator((int)gameObject.transform.position.x, (int)gameObject.transform.position.y, (int)gameObject.transform.position.z, gameObject, wall, door, floor);
        print(bg.getdoorxlocation());
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
