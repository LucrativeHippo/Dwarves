using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTrap : MonoBehaviour {

    private BuffSystem buffsys;
    private float timePassed;
    private float maxTime;

    public float maxTimeToGrow;
    public float minTimeToGrow;
    public float growthRate;

    public float poisonDuration;
    public float poisonTickTime;
    public int poisonDamagePerTick;

    // Use this for initialization
    void Start () {
        buffsys = new BuffSystem();
        maxTime = Random.Range(minTimeToGrow, maxTimeToGrow);
    }
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        Vector3 scale = transform.localScale;
        scale.x += growthRate * Time.deltaTime;
        scale.z += growthRate * Time.deltaTime;
        transform.localScale = scale;

        if (timePassed >= maxTime)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)    
    {
        GameObject victim = other.gameObject;
        ValidBuffTarget valid = victim.GetComponent<ValidBuffTarget>();

        if (valid != null)
        {
            buffsys.dmgApplyingSystem(victim, poisonDuration, poisonTickTime, 
                poisonDamagePerTick, BuffsAndBoons.Effects.Poison);
        } 
    }
}
