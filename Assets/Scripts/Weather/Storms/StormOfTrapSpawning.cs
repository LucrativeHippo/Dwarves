using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormOfTrapSpawning : MonoBehaviour {

    public GameObject trap;
    public float maxRadius;
    public float minRadius;
    public float maxSecondsBetweenSpawns;
    public float minSecondsBetweenSpawns;

    private float timeFromLastSpawn;
    private float timeToNextSpawn;
	
	// Update is called once per frame
	void Update () {
        InBuilding shelterCheck = gameObject.GetComponentInParent<InBuilding>();
        if (shelterCheck == null || !shelterCheck.getPlayerInBuilding())
        {
            timeFromLastSpawn += Time.deltaTime;
            if (timeFromLastSpawn >= timeToNextSpawn)
            {
                float angle = Random.Range(0, 2 * Mathf.PI);
                float radius = Random.Range(minRadius, maxRadius);

                Vector3 pos = gameObject.transform.position;
                pos.x += radius * Mathf.Cos(angle);
                pos.z += radius * Mathf.Sin(angle);
                pos.y = 0.0000001f;

                Instantiate(trap, pos, Quaternion.identity, null);

                timeFromLastSpawn = 0;
                timeToNextSpawn = Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns);
            }
        }
        
	}
}
