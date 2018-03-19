﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-300)]
public class terrainGenerator : MonoBehaviour
{
    public GameObject[] lol;
    //The map that shows the terrain value at each existing coordinate
    public Dictionary<string, terrain> terrainMap;
    public Dictionary<string, resource> resourceMap;
    public Dictionary<string, Chunk> loadedChunks;

    //Starting positions of the player
    [SerializeField]
    private int xPlayerPos;
    [SerializeField]
    private int yPlayerPos;
    [SerializeField]
    private int xPlayerChunkPos;
    [SerializeField]
    private int yPlayerChunkPos;



    [SerializeField]
    private int chunksLoaded = 3;

    /// World starting point
    [SerializeField]
    private static int SEED = 0;
    [SerializeField]
    private static float chunkIntervalSeed = 5f;

    public bool DEBUG = false;
    [SerializeField]
    private int xChunk;
    [SerializeField]
    private int yChunk;
    /*
    //The y size of a generated section of the map
    public int chunkSizeY;
    //The x size of a generated section of the map
    public int chunkSizeX;
	*/

    //A divisor that determines the amount of water generated by the perlin noise function
    [SerializeField]
    private float waterAmount;

    //A divisor that determines amount of specific terrain based on temperature
    [SerializeField]
    private float terrainAmount;

    //A divisor that determines amount of trees 
    [SerializeField]
    private float resourceAmount;

    //The rate that determines rare resource spawn rates
    [SerializeField]
    private int rareResourceRate = 10;

    private float[] thresholds = new float[(int)terrain.GRASS];


    //terrains
    [SerializeField]
    private GameObject Water;
    [SerializeField]
    private GameObject Grass;
    [SerializeField]
    private GameObject Dirt;
    [SerializeField]
    private GameObject Mountain;
    [SerializeField]
    private GameObject Snow;
    [SerializeField]
    private GameObject Sand;
    [SerializeField]
    private GameObject Desert;
    [SerializeField]
    private GameObject Campsite;
    [SerializeField]
    private GameObject Plot;
    [SerializeField]
    private GameObject BuildSign;


    //resources
    [SerializeField]
    private GameObject Tree;

    [SerializeField]
    private GameObject Stone;

    [SerializeField]
    private GameObject Iron;

    [SerializeField]
    private GameObject Gold;

    [SerializeField]
    private GameObject Fish;

    [SerializeField]
    private GameObject Berries;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject NPC;

    [SerializeField]
    private GameObject Diamond;

    [SerializeField]
    private GameObject Coal;


    //Affects the types of terrain that are generated
    [SerializeField]
    private float terrainSeed;

    [SerializeField]
    private float terrainSeed2;

    [SerializeField]
    private float waterSeed;

    [SerializeField]
    private float resourceSeed;

    [SerializeField]
    private float resourceSeed2;

    private GameObject player;

    // Enumerate terrain
    public enum terrain
    {
        WATER,
        DIRT,
        SNOW,
        MOUNTAIN,
        GRASS,
        SAND,
        DESERT,
        CAMPSITE,
        PLOT
    }

    public enum resource
    {
        TREE,
        IRON,
        STONE,
        GOLD,
        FISH,
        MEAT,
        BERRIES,
        NPC,
        ENEMY,
        BUILDSIGN,
        DIAMOND,
        COAL,
        NONE
    }

    private GameObject getResourceObject(resource r)
    {
        switch (r)
        {
            case resource.FISH:
                return Fish;
            case resource.MEAT:
            //return Meat;
            case resource.GOLD:
                return Gold;
            case resource.IRON:
                return Iron;
            case resource.BERRIES:
                return Berries;
            case resource.TREE:
                return Tree;
            case resource.STONE:
            return Stone;
            case resource.NPC:
                return NPC;
            case resource.BUILDSIGN:
                return BuildSign;
            case resource.DIAMOND:
                return Diamond;
            case resource.COAL:
                return Coal;
            default:
                return Tree;
        }
    }

    private float getThreshold(terrain t)
    {
        switch (t)
        {
            case terrain.WATER:
                return 0.2f;
            case terrain.SAND:
                return 0.23f;
            case terrain.DIRT:
                return 0.80f;
            case terrain.MOUNTAIN:
                return 0.50f;
            case terrain.SNOW:
                return 1.0f;
            case terrain.GRASS:
                return 0.65f;
            case terrain.DESERT:
                return 0.30f;
            default:
                return 0.1f;
        }
    }

    private float getResourceThreshold(resource r)
    {
        switch (r)
        {
            case resource.BERRIES:
                return 0.40f;
            case resource.TREE:
                return 0.45f;
            case resource.STONE:
                return 0.90f;
            case resource.MEAT:
                return 0.10f;
            case resource.IRON:
                return 0.46f;
            case resource.GOLD:
                return 0.44f;
            case resource.DIAMOND:
                return 0.35f;
            case resource.COAL:
                return 0.46f;
            case resource.FISH:
                return 0.10f;
            default:
                return 1.0f;
        }
    }

    private GameObject getObject(terrain t)
    {
        switch (t)
        {
            case terrain.WATER:
                return Water;
            case terrain.SAND:
                return Sand;
            case terrain.DIRT:
                return Dirt;
            case terrain.MOUNTAIN:
                return Mountain;
            case terrain.SNOW:
                return Snow;
            case terrain.GRASS:
                return Grass;
            case terrain.DESERT:
                return Desert;
            case terrain.CAMPSITE:
                return Campsite;
            case terrain.PLOT:
                return Plot;
            default:
                return Grass;
        }
    }



    /*---------------------------------------------------------*/
    //Getters and Setters---------------------------------------
    /*---------------------------------------------------------*/

    //Player Positions
    public int getxPlayerPos()
    {
        return xPlayerPos;
    }
    public int getyPlayerPos()
    {
        return yPlayerPos;
    }
    public void setxPlayerPos(int newXPlayerPos)
    {
       xPlayerPos = newXPlayerPos;
    }
    public void setyPlayerPos(int newYPlayerPos)
    {
        yPlayerPos = newYPlayerPos;
    }

    //Player Chunk Positions
    public int getxPlayerChunkPos()
    {
        return xPlayerChunkPos;
    }
    public int getyPlayerChunkPos()
    {
        return yPlayerChunkPos;
    }
    public void setxPlayerChunkPos(int newXPlayerChunkPos)
    {
        xPlayerChunkPos = newXPlayerChunkPos;
    }
    public void setyPlayerChunkPos(int newYPlayerChunkPos)
    {
        yPlayerChunkPos = newYPlayerChunkPos;
    }


    //Climate and resource amounts
    public float getwaterAmount()
    {
        return waterAmount;
    }
    public float getterrainAmount()
    {
        return terrainAmount;
    }
    public float getresourceAmount()
    {
        return resourceAmount;
    }
    public void setwaterAmount(float newwaterAmount)
    {
        waterAmount = newwaterAmount;
    }
    public void setterrainAmount(float newterrainAmount)
    {
        terrainAmount = newterrainAmount;
    }
    public void setresourceAmount(float newresourceAmount)
    {
        resourceAmount = newresourceAmount;
    }


    //The different seeds
    public float getterrainSeed()
    {
        return terrainSeed;
    }
    public float getterrainSeed2()
    {
        return terrainSeed2;
    }
    public float getwaterSeed()
    {
        return waterSeed;
    }
    public float getresourceSeed()
    {
        return resourceSeed;
    }
    public float getresourceSeed2()
    {
        return resourceSeed2;
    }
    public void setterrainSeed(float newterrainSeed)
    {
        terrainSeed = newterrainSeed;
    }
    public void setterrainSeed2(float newterrainSeed2)
    {
        terrainSeed2 = newterrainSeed2;
    }
    public void setwaterSeed(float newwaterSeed)
    {
        waterSeed = newwaterSeed;
    }
    public void setresourceSeed(float newresourceSeed)
    {
        resourceSeed = newresourceSeed;
    }
    public void setresourceSeed2(float newresourceSeed2)
    {
        resourceSeed2 = newresourceSeed2;
    }


    /// <summary>
    /// Gets the position to sample noise.
    /// </summary>
    /// <returns>The noise.</returns>
    /// <param name="val">Value.</param>
    float posNoise(int val, int chunk)
    {
        return (float)(val + chunk * Chunk.SIZE) / 20f + SEED;
    }
    // Use this for initialization
    public void Awake()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //player.transform.position = new Vector3(xPlayerChunkPos + xPlayerPos, 0, yPlayerChunkPos + yPlayerPos);
        RenderSettings.ambientLight = Color.black;
        loadedChunks = new Dictionary<string, Chunk>();
        terrainMap = new Dictionary<string, terrain>();
        resourceMap = new Dictionary<string, resource>();
        int tempx = getxPlayerChunkPos() * Chunk.SIZE + getxPlayerPos();
        int tempy = getyPlayerChunkPos() * Chunk.SIZE + getyPlayerPos();
        
        for (int i = (tempx - 3); i < (tempx + 4); i++)
        {
            for (int j = (tempy - 3); j < (tempy + 4); j++)
            {
                string key = (tempx + i) + " " + (tempy + j);
                if (resourceMap.ContainsKey(key))
                {
                    resourceMap[key] = resource.NONE;
                    
                    
                }
                else
                {
                    resourceMap.Add(key, resource.NONE);
                   
                }
                
            }
        }
        for (int i=xChunk - chunksLoaded; i < xChunk + chunksLoaded + 1; i++ )
        {
            for (int j = yChunk - chunksLoaded; j < yChunk + chunksLoaded + 1; j++)
            {
                generateChunk(i,j);
                //if(i == xChunk+chunksLoaded && j == yChunk + chunksLoaded)
                //{

                  //  GameObject.FindGameObjectWithTag("TownCenter").GetComponent<NavMeshBuildFunction>().build();
                //}
            }
        }
        lol = GameObject.FindGameObjectsWithTag("TownCenter");

        if (GameObject.FindGameObjectWithTag("TownCenter")!=null)
        {
            GameObject.FindGameObjectWithTag("TownCenter").GetComponent<NavMeshBuildFunction>().build();
        }
        
        

    }

    /// <summary>
    /// Generates the chunk at xy chunk position.
    /// </summary>
    /// <returns>The chunk.</returns>
    /// <param name="xPos">X position.</param>
    /// <param name="yPos">Y position.</param>
    public void generateChunk(int xPos, int yPos)
    {

        // If the chunk is alreaady loaded on screen return
        if (loadedChunks.ContainsKey(xPos + " " + yPos))
        {
            return;// loadedChunks [xPos + " " + yPos];
        }


        // Create chunk
        Chunk chunkMap = new Chunk();

		GameObject chunkLoc = new GameObject ("Chunk: " + xPos + " " + yPos);
		chunkLoc.transform.SetPositionAndRotation (new Vector3 (xPos * Chunk.SIZE, 0, yPos * Chunk.SIZE), Quaternion.identity);
        
        for (int y = 0; y < Chunk.SIZE; y++)
        {
            for (int x = 0; x < Chunk.SIZE; x++)
            {


                // Check if this tile is edited already
                if (!addTerrain(x, y, xPos, yPos, chunkMap, terrainMap))
                {
                    Debug.Log("Terrain was not correctly added to tile " + x + " " + y);
                }


                //Generate resources
                addResource(x, y, xPos, yPos, chunkMap, resourceMap);

            }
        }
        loadedChunks[xPos + " " + yPos] = chunkMap;
        GameObject tempTile;
        GameObject tempResource;
        int count = 0;
        for (int y = 0; y < Chunk.SIZE; y++)
        {
            for (int x = 0; x < Chunk.SIZE; x++)
            {
                Position worldPos = new Position(xPos * Chunk.SIZE + x, yPos * Chunk.SIZE + y);
                string key = worldPos.xCoord + " " + worldPos.yCoord;
                tempTile = Instantiate(getObject(terrainMap[key]), new Vector3(worldPos.xCoord, 0, worldPos.yCoord), Quaternion.identity);
                
                if(terrainMap[key] == terrain.PLOT)
                {
                    resourceMap[key] = resource.BUILDSIGN;
                }
                
				tempTile.transform.SetParent(chunkLoc.transform);
                chunkMap.addTileAt(tempTile, x, y, 0);
                if(terrainMap[key] == terrain.CAMPSITE)
                {
                    Instantiate(getObject(terrain.PLOT), new Vector3(worldPos.xCoord, 0, worldPos.yCoord), Quaternion.identity);
                    
                }
                if (resourceMap.ContainsKey(key))
                {
                    if(resourceMap[key] == resource.NONE)
                    {
                        
                    }
                    else if (resourceMap[key] == resource.STONE)
                    {
                        int temp = Random.Range(1, 5);
                        for (int i = 0; i < temp; i++)
                        {
                            int xtemp = Random.Range(-5, 5);
                            int ytemp = Random.Range(-5, 5);
                            if (Random.Range(0, 1000) < rareResourceRate)
                            {
                                tempResource = Instantiate(getResourceObject(resource.DIAMOND), new Vector3(worldPos.xCoord + ((float)xtemp / 10), 0, worldPos.yCoord + ((float)ytemp / 10)), getResourceObject(resourceMap[key]).transform.rotation);
                            }
                            else if(Random.Range(0, 100) < rareResourceRate)
                            {
                                tempResource = Instantiate(getResourceObject(resource.COAL), new Vector3(worldPos.xCoord + ((float)xtemp / 10), 0, worldPos.yCoord + ((float)ytemp / 10)), getResourceObject(resourceMap[key]).transform.rotation);
                            }
                            else
                            {

                                tempResource = Instantiate(getResourceObject(resourceMap[key]), new Vector3(worldPos.xCoord + ((float)xtemp / 10), 0, worldPos.yCoord + ((float)ytemp / 10)), getResourceObject(resourceMap[key]).transform.rotation);
                            }
                            tempResource.transform.SetParent(chunkLoc.transform);
                        }
                    }
                    else if (resourceMap[key] == resource.IRON)
                    {
                        int temp = Random.Range(1, 3);
                        for (int i = 0; i < temp; i++)
                        {
                            int xtemp = Random.Range(-5, 5);
                            int ytemp = Random.Range(-5, 5);
                            tempResource = Instantiate(getResourceObject(resourceMap[key]), new Vector3(worldPos.xCoord + ((float)xtemp / 10), 0, worldPos.yCoord + ((float)ytemp / 10)), getResourceObject(resourceMap[key]).transform.rotation);

                            tempResource.transform.SetParent(chunkLoc.transform);
                        }
                    }
                    else if (resourceMap[key] == resource.TREE)
                    {
                        int temp = Random.Range(1, 5);
                        for (int i = 0; i < temp; i++)
                        {
                            int xtemp = Random.Range(-5, 5);
                            int ytemp = Random.Range(-5, 5);
                            tempResource = Instantiate(getResourceObject(resourceMap[key]), new Vector3(worldPos.xCoord + ((float)xtemp/10), 0, worldPos.yCoord + ((float)ytemp/10)), getResourceObject(resourceMap[key]).transform.rotation);

                            tempResource.transform.SetParent(chunkLoc.transform);
                        }
                    }
                    else if (resourceMap[key] == resource.BERRIES)
                    {
                        int temp = Random.Range(1, 5);
                        for (int i = 0; i < temp; i++)
                        {
                            int xtemp = Random.Range(-5, 5);
                            int ytemp = Random.Range(-5, 5);
                            tempResource = Instantiate(getResourceObject(resourceMap[key]), new Vector3(worldPos.xCoord + ((float)xtemp / 10), 0, worldPos.yCoord + ((float)ytemp / 10)), getResourceObject(resourceMap[key]).transform.rotation);

                            tempResource.transform.SetParent(chunkLoc.transform);
                        }
                    }
                    else {
                        tempResource = Instantiate(getResourceObject(resourceMap[key]), new Vector3(worldPos.xCoord, 0, worldPos.yCoord), getResourceObject(resourceMap[key]).transform.rotation);

                        if (resourceMap[key] == resource.NPC)
                        {
                            tempResource.GetComponent<QuestNPC>().addGoal(tempResource.GetComponent<Skills>().getIntRank());
                        }else{
                            tempResource.transform.SetParent(chunkLoc.transform);
                        }
                        chunkMap.addTileAt(tempTile, x, y, 1);
                    }
                }
                
            }

        }
    }

    bool addTerrain(int xCoord, int yCoord, int xChunkCoord, int yChunkCoord, Chunk chunk, Dictionary<string, terrain> terrainMap)
    {
        
        //GameObject tempTile = null;
        Position worldPos = new Position(xChunkCoord * Chunk.SIZE + xCoord, yChunkCoord * Chunk.SIZE + yCoord);
        string key = worldPos.xCoord + " " + worldPos.yCoord;
        float xNoiseValue = posNoise(xCoord, xChunkCoord);
        float yNoiseValue = posNoise(yCoord, yChunkCoord);
        float waterVal = Mathf.PerlinNoise(xNoiseValue + getwaterSeed() + chunkIntervalSeed * xChunk, yNoiseValue + getwaterSeed() + chunkIntervalSeed * yChunk) / getwaterAmount();
        float terrainVal = Mathf.PerlinNoise(xNoiseValue + getterrainSeed() + chunkIntervalSeed * xChunk, yNoiseValue + getterrainSeed() + chunkIntervalSeed * yChunk) / getterrainAmount();
        float terrainVal2 = Mathf.PerlinNoise(xNoiseValue + getterrainSeed2() + chunkIntervalSeed * xChunk, yNoiseValue + getterrainSeed2() + chunkIntervalSeed * yChunk) / getterrainAmount();

        if (terrainMap.ContainsKey(key))
        {
            // Instantiate saved game object from terrain
            //tempTile = getObject(terrainMap[key]);
        } else if (xChunkCoord == xPlayerChunkPos && yChunkCoord == yPlayerChunkPos && xCoord == xPlayerPos && yCoord == yPlayerPos)
        {
            for (int i = xPlayerPos - 1; i <= xPlayerPos + 1; i++)
            {
                for (int j = yPlayerPos - 1; j <= yPlayerPos + 1; j++)
                {
                    
                    if (i == xPlayerPos && j == yPlayerPos)
                    {
                       
                        worldPos = new Position(xChunkCoord * Chunk.SIZE + i, yChunkCoord * Chunk.SIZE + j);
                        key = worldPos.xCoord + " " + worldPos.yCoord;
                        if (terrainMap.ContainsKey(key))
                        {
                            terrainMap[key] = terrain.CAMPSITE;
                        }
                        else
                        {
                            terrainMap.Add(key, terrain.CAMPSITE);
                        }

                    }
                    else
                    {
                        
                        
                        worldPos = new Position(xChunkCoord * Chunk.SIZE + i, yChunkCoord * Chunk.SIZE + j);
                        key = worldPos.xCoord + " " + worldPos.yCoord;
                        print(key);
                        if (terrainMap.ContainsKey(key))
                        {
                            terrainMap[key] = terrain.PLOT;
                        }
                        else
                        {
                            terrainMap.Add(key, terrain.PLOT);
                        }
                    }
                }
            }
        }
        else if (waterVal < getThreshold(terrain.WATER))
        {
            if (!terrainMap.ContainsKey(key)) { 
            terrainMap.Add(key, terrain.WATER);
            
        }
        }
        else if (waterVal < getThreshold(terrain.SAND))
        {
            if (!terrainMap.ContainsKey(key))
            {
                terrainMap.Add(key, terrain.SAND);
                // tempTile = Sand;
            }
        }

        else
        {
            if (terrainVal <= getThreshold(terrain.DESERT) && terrainVal2 <= getThreshold(terrain.DESERT))
            {
                if (!terrainMap.ContainsKey(key))
                {
                    terrainMap.Add(key, terrain.DESERT);
                    // tempTile = Desert;
                }
            }
            else if (getThreshold(terrain.DESERT) < terrainVal && terrainVal <= getThreshold(terrain.MOUNTAIN)&& getThreshold(terrain.DESERT) < terrainVal2 && terrainVal2 <= getThreshold(terrain.MOUNTAIN))
            {
                if (!terrainMap.ContainsKey(key))
                {
                    terrainMap.Add(key, terrain.MOUNTAIN);
                    // tempTile = Mountain;
                }
            }
            else 
            {
                if (!terrainMap.ContainsKey(key))
                {
                    terrainMap.Add(key, terrain.GRASS);
                    // tempTile = Grass;
                }
            }           
        }
        
        //tempTile = Instantiate(tempTile, new Vector3(worldPos.xCoord, worldPos.yCoord, 0), Quaternion.identity);
        //Adds the terrain into the correct chunk into the first layer
        //chunk.addTileAt(tempTile, xCoord, yCoord, 0);
        return true;

    }


    void addResource(int xCoord, int yCoord, int xChunkCoord, int yChunkCoord, Chunk chunk, Dictionary<string, resource> resourceMap)
    {
        
        GameObject tempResource = null;
        Position worldPos = new Position(xChunkCoord * Chunk.SIZE + xCoord, yChunkCoord * Chunk.SIZE + yCoord);
        string key = worldPos.xCoord + " " + worldPos.yCoord;
        float xNoiseValue = posNoise(xCoord, xChunkCoord);
        float yNoiseValue = posNoise(yCoord, yChunkCoord);
        float waterVal = Mathf.PerlinNoise(xNoiseValue + getwaterSeed() + chunkIntervalSeed * xChunk, yNoiseValue + getwaterSeed() + chunkIntervalSeed * yChunk) / getwaterAmount();
        float resourceVal = Mathf.PerlinNoise(xNoiseValue + getresourceSeed() + chunkIntervalSeed * xChunk, yNoiseValue + getresourceSeed() + chunkIntervalSeed * yChunk) / getresourceAmount();
        float resourceVal2 = Mathf.PerlinNoise(xNoiseValue + getresourceSeed2() + chunkIntervalSeed * xChunk, yNoiseValue + getresourceSeed2() + chunkIntervalSeed * yChunk) / getresourceAmount();
        if (resourceMap.ContainsKey(key))
        {
            if(!(resourceMap[key] == resource.NONE))
            {
                tempResource = getResourceObject(resourceMap[key]);
            }
            
            
        }else if (terrainMap[key] == terrain.PLOT)
        {
            
            resourceMap.Add(key, resource.BUILDSIGN);
        }
        else if (waterVal < getThreshold(terrain.WATER))
        {

            if(Random.Range(0,30)< 2)
            {
                tempResource = Fish;
                resourceMap.Add(key, resource.FISH);
            }

        }
        else if (0 <= resourceVal && resourceVal < getResourceThreshold(resource.TREE) && 0 <= resourceVal2 && resourceVal2 < getResourceThreshold(resource.TREE))
        {

            if (terrainMap[key] == terrain.GRASS && !resourceMap.ContainsKey(key))
            {
                if (Random.Range(0, 150) < rareResourceRate)
                {
                    tempResource = Berries;
                    resourceMap.Add(key, resource.BERRIES);
                }
                else
                {
                    tempResource = Tree;
                    resourceMap.Add(key, resource.TREE);
                }
                
            }
            
        }
        else if (0 <= resourceVal && resourceVal < getResourceThreshold(resource.IRON) && 0 <= resourceVal2 && resourceVal2 < getResourceThreshold(resource.IRON))
        {
            if (terrainMap[key] == terrain.MOUNTAIN)
            {
                tempResource = Iron;
                resourceMap.Add(key, resource.IRON);
            }
        }
        else if (getResourceThreshold(resource.STONE) - 0.4 <= resourceVal && resourceVal < getResourceThreshold(resource.STONE) && getResourceThreshold(resource.STONE) - 0.4 <= resourceVal2 && resourceVal2 < getResourceThreshold(resource.STONE))
        {
            if (terrainMap[key] == terrain.MOUNTAIN && !resourceMap.ContainsKey(key))
            {
                tempResource = Stone;
                resourceMap.Add(key, resource.STONE);
            }
        }
        else if (0 <= resourceVal && resourceVal < getResourceThreshold(resource.GOLD) && 0 <= resourceVal2 && resourceVal2 < getResourceThreshold(resource.GOLD))
        {
            tempResource = Gold;
            resourceMap.Add(key, resource.GOLD);
        }else if (Random.Range(0,1500) < rareResourceRate)
        {
            resourceMap.Add(key, resource.GOLD);
        }

            if (!resourceMap.ContainsKey(key))
        {

            if (Random.Range(1, 600) == 1)
            {
                resourceMap.Add(key, resource.NPC);
            }
            

        }
    }

    private Position debugPos = new Position(0,0);
        // Update is called once per frame
        void Update()
    {
        if (DEBUG)
        {
            debugPos.xCoord += Input.GetKeyDown(KeyCode.J) ? -1 : 0;
            debugPos.xCoord += Input.GetKeyDown(KeyCode.L) ? 1 : 0;

            debugPos.yCoord += Input.GetKeyDown(KeyCode.K) ? -1 : 0;
            debugPos.yCoord += Input.GetKeyDown(KeyCode.I) ? 1 : 0;

            if (debugPos.xCoord != 0 || debugPos.yCoord != 0)
            {
                generateChunk(debugPos.xCoord, debugPos.yCoord);
            }
        }
    }
}
