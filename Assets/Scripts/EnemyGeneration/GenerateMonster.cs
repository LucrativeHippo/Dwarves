using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonster : MonoBehaviour {
    private int currentDay;
    public Weather.weatherTypes currentWeather;
    public LinkedList<Enemy> enemyList;
    private terrainGenerator terrainMap;
    private GameObject terrain_generator;
    private GameObject calendarObject;
    private Weather weatherScript;
    private Calendar calendar;
    
    //Basic Difficulty slider
    public int numEnemies;


    //Monster types
    public GameObject heatMonster;
    public GameObject snowMonster;
    public GameObject acidMonster;
    public GameObject devilMonster;
    public GameObject lightningMonster;


    

    private bool test = true;

	// Use this for initialization
	void Start () {
        enemyList = new LinkedList<Enemy>();
        terrain_generator = GameObject.Find("Terrain Generator");
        terrainMap = terrain_generator.GetComponent<terrainGenerator>();
        calendarObject = GameObject.Find("Calendar");
        weatherScript = calendarObject.GetComponent<Weather>();
        calendar = calendarObject.GetComponent<Calendar>();
    }

    // Update is called once per frame
    void Update() {
        
        if (terrainMap!=null && test)
        {

            SpawnMonsters(currentWeather);
            
            test = false;
        }
        
    }
    /*
    public void DeleteMonsters(weather currentWeather)
    {
        foreach (Enemy i  in enemyList)
        {
            if(i.preferredType.Equals(currentWeather))
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }*/

    public void SpawnMonsters(Weather.weatherTypes currentWeather)
    {
        GameObject temp = null;
        if(currentWeather == Weather.weatherTypes.SUPER_HOT)
        {
            putMonsterOnMap(heatMonster);
        }else if (currentWeather == Weather.weatherTypes.BLIZZARD)
        {
            putMonsterOnMap(snowMonster);
        }
        else if (currentWeather == Weather.weatherTypes.ACID_RAIN)
        {
            putMonsterOnMap(acidMonster);
        }
        else if (currentWeather == Weather.weatherTypes.HELLFIRE)
        {
            putMonsterOnMap(devilMonster);
        }
        else if (currentWeather == Weather.weatherTypes.SCARY_LIGHTNING)
        {
            putMonsterOnMap(lightningMonster);
        }


    }

    public void putMonsterOnMap(GameObject monster)
    {
        int xdirection = Random.Range(-10, 10);
        int ydirection = Random.Range(-10, 10);
        int currentEnemies = 0;
            while (currentEnemies < numEnemies)
            {
            
                GameObject newMonster = Instantiate(monster, new Vector2(terrainMap.xPlayerChunkPos + xdirection * terrainMap.chunkSize + currentEnemies, terrainMap.yPlayerChunkPos + ydirection * terrainMap.chunkSize + currentEnemies), Quaternion.identity);
                enemyList.AddLast(newMonster.GetComponent<Enemy>());
                currentEnemies++;
            }
    }

    public LinkedList<Enemy> getAllEnemies()
    {
        return enemyList;
    }
}
