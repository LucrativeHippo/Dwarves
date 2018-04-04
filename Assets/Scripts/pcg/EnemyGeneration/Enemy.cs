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
}
