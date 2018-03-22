using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormOfSlow : GenericStorm {

    public float slowDecimal;
    public float slowDuration;
    public float slowRenewalTime;

    private float timeSinceLastRenewal;
    protected BuffSystem buffsys;

    private GameObject player;

	// Use this for initialization
	void Start () {
        buffsys = new BuffSystem();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastRenewal += Time.deltaTime;
        if (timeSinceLastRenewal >= slowRenewalTime)
        {
            timeSinceLastRenewal = 0;

            slow(player);

            List<GameObject> NPCs = MetaScript.GetNPC().getNPCs();
            for (int i = 0; i < NPCs.Count; i++)
            {
                slow(NPCs[i]);
            }
        }
	}

    protected virtual void slow(GameObject victim)
    {
        InBuilding shelterCheck = victim.GetComponent<InBuilding>();
        if (shelterCheck == null || !shelterCheck.isInBuilding())
        {
            buffsys.slowApplyingSystem(victim, slowDuration, slowDecimal);
        }
    }
}
