﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainGenerator : MonoBehaviour
{

    //The map that shows the terrain value at each existing coordinate
	private Dictionary<string, terrain> terrainMap;
	public Dictionary<string, Chunk> loadedChunks;

	/// Number of chunks that make up the world
	private static int WORLD_SIZE = 1;
	/// World starting point
	public static int SEED = 0;

    public static float chunkIntervalSeed = 5f;

	public bool DEBUG = false;

	public int xChunk;
	public int yChunk;
	/*
    //The y size of a generated section of the map
    public int chunkSizeY;
    //The x size of a generated section of the map
    public int chunkSizeX;
	*/

    //A divisor that determines the amount of water generated by the perlin noise function
    public float waterAmount;

    //A divisor that determines amount of specific terrain based on temperature
    public float terrainAmount;

	private float [] thresholds = new float[(int)terrain.GRASS];

    public GameObject Water;

    public GameObject Grass;

    public GameObject Dirt;

    public GameObject Stone;

    public GameObject Snow;

    public GameObject Sand;

    public GameObject Desert;

    //Affects the types of terrain that are generated
    public float terrainSeed;

    public float waterSeed;

    // Enumerate terrain
	private enum terrain {
		WATER,
		DIRT,
		SNOW,
		STONE,
		GRASS,
        SAND,
        DESERT
	}

	private float getThreshold(terrain t){
		switch (t) {
		case terrain.WATER:
			return 0.2f;
        case terrain.SAND:
            return 0.25f;
		case terrain.DIRT:
			return 0.80f;
		case terrain.STONE:
			return 0.90f;
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

	private GameObject getObject(terrain t){
		switch (t) {
		case terrain.WATER:
			return Water;
		case terrain.SAND:
			return Sand;
		case terrain.DIRT:
			return Dirt;
		case terrain.STONE:
			return Stone;
		case terrain.SNOW:
			return Snow;
		case terrain.GRASS:
			return Grass;
		case terrain.DESERT:
			return Desert;
		default:
			return Grass;
		}
	}

	/// <summary>
	/// Gets the position to sample noise.
	/// </summary>
	/// <returns>The noise.</returns>
	/// <param name="val">Value.</param>
	float posNoise(int val, int chunk){
		return (float)(val+ chunk*Chunk.SIZE)/20f + SEED;
	}
    // Use this for initialization
    public void Start()
	{
		loadedChunks = new Dictionary<string, Chunk>();
		terrainMap = new Dictionary<string, terrain>();
		generateChunk (xChunk,yChunk);
        generateChunk(xChunk - 1, yChunk + 0);
        generateChunk(xChunk - 1, yChunk - 1);
        generateChunk(xChunk + 0, yChunk - 1);

        //System.Random randomNum = new System.Random();
    }


	/// <summary>
	/// Generates the chunk at xy chunk position.
	/// </summary>
	/// <returns>The chunk.</returns>
	/// <param name="xPos">X position.</param>
	/// <param name="yPos">Y position.</param>
	void generateChunk(int xPos, int yPos){

		// If the chunk is alreaady loaded on screen return
		if (loadedChunks.ContainsKey (xPos + " " + yPos)) {
			return;// loadedChunks [xPos + " " + yPos];
		}


		// Create chunk
		Chunk chunkMap = new Chunk();

		for (int y = 0; y < Chunk.SIZE; y++)
		{
			for (int x = 0; x < Chunk.SIZE; x++)
			{
				GameObject tempTile;
				Position worldPos = new Position (xPos * Chunk.SIZE + x, yPos*Chunk.SIZE+y);
				string key = worldPos.xCoord+" "+worldPos.yCoord;

				float xNoiseValue = posNoise(x,xChunk);
				float yNoiseValue = posNoise(y,yChunk);

				float waterVal = Mathf.PerlinNoise (xNoiseValue + waterSeed + chunkIntervalSeed*xPos, yNoiseValue + waterSeed + chunkIntervalSeed*yPos) / waterAmount;
				float terrainVal = Mathf.PerlinNoise(xNoiseValue + terrainSeed + chunkIntervalSeed * xPos, yNoiseValue + terrainSeed + chunkIntervalSeed * yPos) / terrainAmount;

				// Check if this tile is edited already
				if(terrainMap.ContainsKey(key))
				{
					// Instantiate saved game object from terrain
					tempTile = getObject(terrainMap[key]);
				}else if (waterVal < getThreshold(terrain.WATER))
				{
					tempTile = Water;
				}else if (waterVal < getThreshold(terrain.SAND))
				{
					tempTile = Sand;
				}

				else
				{
					if (terrainVal <= getThreshold(terrain.DESERT))
					{
						tempTile = Desert;
					}
					else if (getThreshold(terrain.DESERT) < terrainVal && terrainVal <= getThreshold(terrain.GRASS))
					{
						tempTile = Grass;
					}
					else if (getThreshold(terrain.GRASS) < terrainVal && terrainVal <= getThreshold(terrain.DIRT))
					{
						tempTile = Dirt;
					}
					else if (getThreshold(terrain.DIRT) < terrainVal && terrainVal <= getThreshold(terrain.STONE))
					{
						tempTile = Stone;
					}
					else 
					{
						tempTile = Snow;
					}
				}

				tempTile = Instantiate(tempTile, new Vector3(worldPos.xCoord, worldPos.yCoord, 0), Quaternion.identity);
				chunkMap.addTileAt (tempTile, x, y);
			}
		}
		loadedChunks[xPos+" "+yPos] = chunkMap;
	}

    // Update is called once per frame
    void Update()
    {
		if (DEBUG) {
			Position changePos = new Position (0, 0);
			changePos.xCoord += Input.GetKeyDown (KeyCode.J) ? -1 : 0;
			changePos.xCoord += Input.GetKeyDown (KeyCode.L) ? 1 : 0;

			changePos.yCoord += Input.GetKeyDown (KeyCode.K) ? -1 : 0;
			changePos.yCoord += Input.GetKeyDown (KeyCode.I) ? 1 : 0;

			if (changePos.xCoord != 0 || changePos.yCoord != 0) {
				xChunk += changePos.xCoord;
				yChunk += changePos.yCoord;
				generateChunk (xChunk, yChunk);
			}
		}
    }
}
