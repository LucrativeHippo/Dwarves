using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPortal : MonoBehaviour {

    private Controls controls;

    [SerializeField]
    private float timer = 2.0f;

    private float timer2;

    private GameObject player;

    [SerializeField]
    private int resourceCost = 1;

    [SerializeField]
    private ResourceTypes costType = ResourceTypes.DIAMOND;

    private InBuilding buildingCheck;

    private void Start()
    {
        timer2 = timer;
        player = MetaScript.getPlayer();
        
        buildingCheck = player.GetComponent<InBuilding>();
        controls = MetaScript.GetControls();
    }

    // Update is called once per frame
    void Update () {
        if (controls.keyDown(controls.TownPortal))
        {
            bool inBuilding = false;
            if (buildingCheck != null)
            {
                inBuilding = buildingCheck.getPlayerInBuilding();
            }

            if (MetaScript.getRes().hasResource(costType, resourceCost) && !inBuilding)
            {
                MetaScript.getRes().addResource(costType,-resourceCost);
                MetaScript.preTeleport();
                transform.parent.transform.position = MetaScript.getTownCenter().transform.position + new Vector3(0.5f, 0, -0.5f);
                MetaScript.postTeleport();
            }

        }
    }

    public bool CoolDown()
    {
        timer += Time.deltaTime;

        if (timer >= timer2)
        {
            timer = 0;
            return true;

        }
        return false;
    }
}
