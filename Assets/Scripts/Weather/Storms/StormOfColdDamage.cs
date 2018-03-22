using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormOfColdDamage : GenericStorm {

    public int damagePerTick;
    public float tickTime;

    private float timePassed;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        bool isProtected = MetaScript.getGlobal_Stats().getHasColdProtection();

        if (!isProtected)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= tickTime)
            {
                timePassed = 0;

                heatExhaust(player);

                List<GameObject> NPCs = MetaScript.getMeta().GetComponent<OwnedNPCList>().getNPCs();
                for (int i = 0; i < NPCs.Count; i++)
                {
                    heatExhaust(NPCs[i]);
                }
            }
        }
        
	}

    private void heatExhaust(GameObject victim)
    {
        InBuilding shelterCheck = victim.GetComponent<InBuilding>();
        if (shelterCheck == null || !shelterCheck.isInBuilding())
        {
            victim.GetComponent<Health>().damage(damagePerTick);
        }
    }
}
