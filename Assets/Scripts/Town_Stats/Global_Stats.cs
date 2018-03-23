using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Stats : MonoBehaviour {
    [SerializeField]
    private float foodSaved = 0;

    [SerializeField]
    private float militaryAbility = 1;

    [SerializeField]
    private float healthPool;

    [SerializeField]
    private float gatherMultiplier;

    [SerializeField]
    private bool hasHeatProtection;

    [SerializeField]
    private bool hasColdProtection;


    public float getFoodSaved()
    {
        return foodSaved;
    }

    public void setFoodSaved(float food)
    {
        foodSaved = food;
    }

    public float getMilitaryAbility()
    {
        return militaryAbility;
    }

    public void setMilitaryAbility(float military)
    {
        militaryAbility = military;
    }

    public float getHealthPool()
    {
        return healthPool;
    }

    public void setHealthPool(float health)
    {
        healthPool = health;
    }

    public void setGatherMultiplier(float mult)
    {
        gatherMultiplier = mult;
        if (gatherMultiplier < 0)
        {
            gatherMultiplier = 0;
        }
    }

    public float getGatherMultiplier()
    {
        return gatherMultiplier;
    }

    public void setHasHeatProtection(bool has)
    {
        hasHeatProtection = has;
    }

    public bool getHasHeatProtection()
    {
        return hasHeatProtection;
    }

    public void setHasColdProtection(bool has)
    {
        hasColdProtection = has;
    }

    public bool getHasColdProtection()
    {
        return hasColdProtection;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
