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
        
        if (!this.enabled)
            return;
        player.SetActive(false);
        player.transform.position = new Vector3(bg.getdoorxlocation() + bg.getxlocation(), bg.getylocation(), bg.getdoorzlocation() + bg.getzlocation());
        player.SetActive(true);
    }

    // Use this for initialization
    void Start () {
        bg = new building_generator((int)gameObject.transform.position.x, (int)gameObject.transform.position.y, (int)gameObject.transform.position.z, gameObject, wall, door, floor);
        if(bg == null)
        {
            Debug.Log("The building_generator object is null.");
        }
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("The player object is null.");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
	}
}
