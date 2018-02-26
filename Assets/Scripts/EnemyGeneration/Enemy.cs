using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public weather preferredType;

    public enum weather
    {
        SUNNY,
        CLOUDY,
        RAIN,
        SNOW,
        BLIZZARD,
        HELLFIRE,
        SCARY_LIGHTNING,
        ACID_RAIN,
        SUPER_HOT,
        PERFECT_WEATHER
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
