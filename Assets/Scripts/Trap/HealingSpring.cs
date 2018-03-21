using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSpring : MonoBehaviour {

    //The list of colliders currently inside the trigger
    private List<Collider> targets = new List<Collider>();
    private BuffSystem buffsys;
    private float timeFromLastApply;

    public float regenDuration;
    public float regenTickTime;
    public int healingPerTick;

    public float timeBetweenReapplication;


    // Use this for initialization
    void Start()
    {
        buffsys = new BuffSystem();
    }

    void Update()
    {
        timeFromLastApply += Time.deltaTime;
        if (timeFromLastApply > timeBetweenReapplication)
        {
            timeFromLastApply = 0;
            foreach(Collider victim in targets)
            {
                buffsys.regenApplyingSystem(victim.gameObject, regenDuration, 
                    regenTickTime, healingPerTick);   
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject victim = other.gameObject;
        ValidBuffTarget valid = victim.GetComponent<ValidBuffTarget>();

        if (valid != null)
        {
            buffsys.regenApplyingSystem(victim.gameObject, regenDuration, 
                regenTickTime, healingPerTick);

            if (!targets.Contains(other))
            {
                targets.Add(other);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject victim = other.gameObject;
        ValidBuffTarget valid = victim.GetComponent<ValidBuffTarget>();

        if (valid != null)
        {
            if (targets.Contains(other))
            {
                targets.Remove(other);
            }
        }
    }
}
