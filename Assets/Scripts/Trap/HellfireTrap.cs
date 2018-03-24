using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellfireTrap : MonoBehaviour {

    public float fallingScale;
    public float timeToFall;
    public float startPosY;

    public float fireScale;
    public float timeToSmolder;

    public float burnDuration;
    public float burnTickTime;
    public int burnDamagePerTick;

    private BuffSystem buffsys;
    private lifeStage stage;
    private float timePassed;

    private enum lifeStage
    {
        FALLING,
        SMOLDERING
    }

	// Use this for initialization
	void Start () {
        Vector3 pos = transform.position;
        pos.y += startPosY;
        transform.position = pos;

        Vector3 scale = transform.localScale;
        scale.x = fallingScale;
        scale.y = fallingScale;
        scale.z = fallingScale;
        transform.localScale = scale;

        stage = lifeStage.FALLING;
        buffsys = new BuffSystem();
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        switch (stage)
        {
            case lifeStage.FALLING:
                fall();
                break;
            case lifeStage.SMOLDERING:
                smolder();
                break;
            default:
                Debug.LogError("Hellfire trap stage not found.");
                break;
        }
	}

    private void fall()
    {
        if (timePassed >= timeToFall)
        {
            timePassed = 0;
            stage = lifeStage.SMOLDERING;

            Vector3 scale = transform.localScale;
            scale.x = fireScale;
            scale.y = fireScale;
            scale.z = fireScale;
            transform.localScale = scale;
        }
        else
        {
            float t = timePassed / timeToFall;
            Vector3 pos = transform.position;
            pos.y = Mathf.Lerp(startPosY, 0, t);
            transform.position = pos;
        }
    }

    private void smolder()
    {
        if (timePassed >= timeToSmolder)
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
            if (!checkIfInBuilding(victim))
            {
                buffsys.dmgApplyingSystem(victim, burnDuration, burnTickTime,
                burnDamagePerTick, BuffsAndBoons.Effects.Burn);
            }
        }
    }

    private bool checkIfInBuilding(GameObject victim)
    {
        InBuilding buildingCheck = victim.GetComponent<InBuilding>();
        if (buildingCheck == null)
        {
            return false;
        }
        else
        {
            return buildingCheck.getPlayerInBuilding();
        }
    }
}
