using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormOfSnow : MonoBehaviour {

    public float slowDecimal;
    public float slowDuration;
    public float slowRenewalTime;

    private float timeSinceLastRenewal;
    private BuffSystem buffsys;

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

            List<GameObject> NPCs = MetaScript.getMeta().GetComponent<OwnedNPCList>().getNPCs();
            foreach (GameObject victim in NPCs)
            {
                slow(victim);
            }
        }
	}

    private void slow(GameObject victim)
    {
        InBuilding shelterCheck = victim.GetComponent<InBuilding>();
        if (shelterCheck == null || !shelterCheck.getPlayerInBuilding())
        {
            buffsys.slowApplyingSystem(victim, slowDuration, slowDecimal);
        }
    }
}
