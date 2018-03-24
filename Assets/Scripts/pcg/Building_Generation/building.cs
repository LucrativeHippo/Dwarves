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

    ParticleSystem[] ps;
    GameObject player;

    private int xpos;
    private int ypos;
    private int zpos;

    private building_generator bg;


    public void recieveAction()
    {
        
        if (!this.enabled)
            return;

        player.GetComponent<DynamicGeneration>().enabled = false;
        MetaScript.GetInBuilding().setPlayerInBuilding(true);
        player.SetActive(false);
        player.transform.position = new Vector3(bg.getdoorxlocation() + bg.getxlocation(), bg.getylocation(), bg.getdoorzlocation() + bg.getzlocation());
        player.GetComponent<LocalNavMeshBuilder>().enabled = true;
        player.SetActive(true);

        player.GetComponent<InBuilding>().setPlayerInBuilding(true);
        disableParticleSystems();
    }

    // Use this for initialization
    void Start () {
        bg = new building_generator((int)gameObject.transform.position.x, (int)gameObject.transform.position.y, (int)gameObject.transform.position.z, gameObject, wall, door, floor);
        if(bg == null)
        {
            Debug.Log("The building_generator object is null.");
        }
        player = MetaScript.getPlayer();
        if (player == null)
        {
            Debug.Log("The player object is null.");
        }
        else
        {
            ps = player.GetComponentsInChildren<ParticleSystem>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(player == null)
        {
            player = MetaScript.getPlayer();
            Debug.Log("Building had to find player again");
        }
	}

    private void disableParticleSystems()
    {
        if (player.GetComponent<InBuilding>().getPlayerInBuilding())
        {
            ps = player.GetComponentsInChildren<ParticleSystem>();
            if (ps != null)
            {
                for (int i = 0; i < ps.Length; i++)
                {
                    ps[i].Stop();
                }
            }
        }
    }
}
