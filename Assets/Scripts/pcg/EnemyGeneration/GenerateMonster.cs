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
    public GameObject evilPenguin;
    //public GameObject snowMonster;
    //public GameObject acidMonster;
    //public GameObject devilMonster;
    //public GameObject lightningMonster;


    

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
    
    public void SpawnMonsters(Weather.weatherTypes currentWeather)
    {
        if(currentWeather == Weather.weatherTypes.SUPER_HOT)
        {
            putMonsterOnMap(evilPenguin);
        }else if (currentWeather == Weather.weatherTypes.BLIZZARD)
        {
            putMonsterOnMap(evilPenguin);
        }
        else if (currentWeather == Weather.weatherTypes.ACID_RAIN)
        {
            putMonsterOnMap(evilPenguin);
        }
        else if (currentWeather == Weather.weatherTypes.HELLFIRE)
        {
            putMonsterOnMap(evilPenguin);
        }
        else if (currentWeather == Weather.weatherTypes.SCARY_LIGHTNING)
        {
            putMonsterOnMap(evilPenguin);
        }


    }

    public void putMonsterOnMap(GameObject monster)
    {
        int[] range = { -10, 0, 10 };
        int xdirection = Random.Range(0,2);
        int ydirection = Random.Range(0,2);
        while(xdirection==1 && ydirection == 1)
        {
            ydirection = Random.Range(0, 2);
        }
        
        int currentEnemies = 0;
            while (currentEnemies < numEnemies)
            {
            
                GameObject temp = Instantiate(monster, new Vector3(range[xdirection] * Chunk.SIZE, 0.06666667f, range[ydirection] * Chunk.SIZE), Quaternion.identity);
            print(temp.transform.position);
            currentEnemies++;
            }
    }
}
