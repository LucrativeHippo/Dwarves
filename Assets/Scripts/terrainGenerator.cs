using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainGenerator : MonoBehaviour
{

    //The map that shows the terrain value at each existing coordinate
    private Dictionary<Tuple, int> terrainMap;
    //The y size of a generated section of the map
    public int chunkSizeY;
    //The x size of a generated section of the map
    public int chunkSizeX;

    //Each terrain set to its specific integer value
    private static int GRASS = 1;
    private static int WATER = 2;
    private static int DIRT = 3;
    private static int SNOW = 4;

    // Use this for initialization
    void Start()
    {
        terrainMap = new Dictionary<Tuple, int>();
        System.Random randomNum = new System.Random();
        for (int i = 0; i < chunkSizeY; i++)
        {
            for (int j = 0; j < chunkSizeX; j++)
            {
                int leftTerrain = 1000;
                int rightTerrain = 1000;
                int upTerrain = 1000;
                int downTerrain = 1000;
                int terrainDivisor = 0;
                //Checks the surrounding terrain types
                if (terrainMap.ContainsKey(new Tuple(i - 1, j)))
                {
                    leftTerrain = terrainMap[new Tuple(i - 1, j)];
                    terrainDivisor++;
                }
                if (terrainMap.ContainsKey(new Tuple(i + 1, j)))
                {
                    rightTerrain = terrainMap[new Tuple(i + 1, j)];
                    terrainDivisor++;
                }
                if (terrainMap.ContainsKey(new Tuple(i, j - 1)))
                {
                    downTerrain = terrainMap[new Tuple(i, j - 1)];
                    terrainDivisor++;
                }
                if (terrainMap.ContainsKey(new Tuple(i, j + 1)))
                {
                    upTerrain = terrainMap[new Tuple(i, j + 1)];
                    terrainDivisor++;
                }
                int value = 1000;
                while (value != 1000)
                {
                    int temp = randomNum.Next(1, 100);
                    if (temp <= 24)
                    {
                        //give the tile the left terrain type
                        value = leftTerrain;
                    }
                    if (temp > 24 && temp <= 48)
                    {
                        //give the tile the right terrain type
                        value = rightTerrain;
                    }
                    if (temp > 48 && temp <= 72)
                    {
                        //give the tile the upper terrain type
                        value = upTerrain;
                    }
                    if (temp > 72 && temp <= 96)
                    {
                        //give the tile the lower terrain type
                        value = downTerrain;
                    }
                    if (temp > 96)
                    {
                        //give the tile a random terrain type
                        value = randomNum.Next(1, 4);
                    }
                }
            }
        }







    }

    // Update is called once per frame
    void Update()
    {

    }
}
