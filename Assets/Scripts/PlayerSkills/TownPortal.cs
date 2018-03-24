using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPortal : MonoBehaviour {

    public KeyCode actionKey;

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
        player = MetaScript.getPlayer().GetComponentInChildren<actor>().gameObject;
        if (player != null)
        {
            buildingCheck = player.GetComponent<InBuilding>();
        }
    }

    // Update is called once per frame
    void Update () {
        if (player != null)
        {
            if (Input.GetKey(actionKey))
            {
                bool inBuilding = false;
                if (buildingCheck != null)
                {
                    inBuilding = buildingCheck.getPlayerInBuilding();
                }

                if (MetaScript.getRes().hasResource(costType, resourceCost) && !inBuilding)
                {
                    MetaScript.getRes().addResource(costType,-resourceCost);
                   transform.parent.transform.position = MetaScript.getTownCenter().transform.position + new Vector3(0.5f, 0, -0.5f);
                }

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
