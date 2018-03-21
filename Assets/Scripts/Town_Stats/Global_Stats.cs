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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
