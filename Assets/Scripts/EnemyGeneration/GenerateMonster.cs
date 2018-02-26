using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonster : MonoBehaviour {
    private int currentDay;
    public weather currentWeather;
    public LinkedList<Enemy> enemyList;
    private terrainGenerator terrainMap;
    private GameObject terrain_generator;

    //Basic Difficulty slider
    public int numEnemies;


    //Monster types
    public GameObject heatMonster;
    public GameObject snowMonster;
    public GameObject acidMonster;
    public GameObject devilMonster;
    public GameObject lightningMonster;


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

    private bool test = true;

	// Use this for initialization
	void Start () {
        enemyList = new LinkedList<Enemy>();
        terrain_generator = GameObject.Find("Terrain Generator");
        terrainMap = terrain_generator.GetComponent<terrainGenerator>();
        

    }

    // Update is called once per frame
    void Update() {
        
        if(terrainMap == null)
        {
           
            terrainMap = terrain_generator.GetComponent<terrainGenerator>();
        }
        if (terrainMap!=null && test)
        {

            SpawnMonsters(currentWeather);
            
            test = false;
        }
        //This is not implemented yet
        /*
        if (currentDay != getCurrentDay from weather object )
        {
            currentWeather = GetCurrentDaysWeather;
            SpawnMonsters(currentWeather);
            DeleteMonsters(currentWeather);
        }
        else
        {
            //Do Nothing
        }
        */

    }
    public void DeleteMonsters(weather currentWeather)
    {
        foreach (Enemy i  in enemyList)
        {
            if(i.preferredType.Equals(currentWeather))
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    public void SpawnMonsters(weather currentWeather)
    {
        GameObject temp = null;
        if(currentWeather == weather.SUPER_HOT)
        {
            putMonsterOnMap(heatMonster);
        }else if (currentWeather == weather.BLIZZARD)
        {
            putMonsterOnMap(snowMonster);
        }
        else if (currentWeather == weather.ACID_RAIN)
        {
            putMonsterOnMap(acidMonster);
        }
        else if (currentWeather == weather.HELLFIRE)
        {
            putMonsterOnMap(devilMonster);
        }
        else if (currentWeather == weather.SCARY_LIGHTNING)
        {
            putMonsterOnMap(lightningMonster);
        }


    }

    public void putMonsterOnMap(GameObject monster)
    {
        int xdirection = Random.Range(-10, 10);
        int ydirection = Random.Range(-10, 10);
        int currentEnemies = 0;
       // foreach (Chunk i in terrainMap.loadedChunks)
       // {
            //int currentEnemies = 0;
            while (currentEnemies < numEnemies)
            {
            
                Instantiate(monster, new Vector2(terrainMap.xPlayerChunkPos + xdirection * terrainMap.chunkSize + currentEnemies, terrainMap.yPlayerChunkPos + ydirection * terrainMap.chunkSize + currentEnemies), Quaternion.identity);
            currentEnemies++;
            }
       // }
    }
}
