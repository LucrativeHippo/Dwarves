using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormBringer : MonoBehaviour {

    public GameObject acidStorm;
    public GameObject blizzardStorm;
    public GameObject frostbiteStorm;
    public GameObject gatheringStorm;
    public GameObject heatwaveStorm;
    public GameObject hellfireStorm;
    public GameObject perfectStorm;
    public GameObject snowStorm;

    private GameObject player;

    private void Start()
    {
        
    }

    public void initializeInternals()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void resetStorms(float temp, Weather.weatherTypes weather)
    {
        removeStorms(player, temp, weather);
        addStorms(temp, weather);
    }

    private void addStorms(float temp, Weather.weatherTypes weather)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (temp > 30)
        {
            Instantiate(heatwaveStorm, player.transform.position, Quaternion.identity, player.transform);
        }
        if (temp < -10)
        {
            Instantiate(gatheringStorm, player.transform.position, Quaternion.identity, player.transform);
        }
        if (temp < -30)
        {
            Instantiate(frostbiteStorm, player.transform.position, Quaternion.identity, player.transform);
        }

        switch (weather)
        {
            case Weather.weatherTypes.ACID_RAIN:
                Instantiate(acidStorm, player.transform.position, Quaternion.identity, player.transform);
                break;
            case Weather.weatherTypes.BLIZZARD:
                Instantiate(blizzardStorm, player.transform.position, Quaternion.identity, player.transform);
                break;
            case Weather.weatherTypes.HELLFIRE:
                Instantiate(hellfireStorm, player.transform.position, Quaternion.identity, player.transform);
                break;
            case Weather.weatherTypes.PERFECT_WEATHER:
                Instantiate(perfectStorm, player.transform.position, Quaternion.identity, player.transform);
                break;
            case Weather.weatherTypes.SNOW:
                Instantiate(snowStorm, player.transform.position, Quaternion.identity, player.transform);
                break;
            default:
                break;
        }
    }

    private void removeStorms(GameObject target, float temp, Weather.weatherTypes weather)
    {
        GenericStorm[] storms = target.GetComponentsInChildren<GenericStorm>();

        for (int i = 0; i < storms.Length; i++)
        {
            storms[i].removeStorm();
        }
    }
}
