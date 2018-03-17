using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cave_generation : MonoBehaviour {

    [SerializeField]
    private int CAVE_DIMENSIONS = 20;

    [SerializeField]
    GameObject caveWall;
    [SerializeField]
    GameObject caveFloor;
    [SerializeField]
    GameObject caveEntrance;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject gold;

    [SerializeField]
    GameObject diamond;

    private bool[,] cave;

    private int caveEntrancex;
    private int caveEntrancez;

    private int caveSize = 150;

    [SerializeField]
    private int chanceToStartAlive = 40;
    [SerializeField]
    private int deathLimit = 3;
    [SerializeField]
    private int birthLimit = 4;
    [SerializeField]
    private int numSteps = 6;

    private bool doorPlaced = false;

	// Use this for initialization
	void Start () {
        cave = new bool[CAVE_DIMENSIONS, CAVE_DIMENSIONS];
        initialiseCave();
        
        for(int i=0; i < numSteps; i++)
        {
            cave = updateCave();
        }
        instantiateCave();
        
    }

    public void instantiateCave()
    {
        
        for (int x = 0; x < CAVE_DIMENSIONS; x++)
        {
            
            for (int z = 0; z < CAVE_DIMENSIONS; z++)
            {
                if (cave[x, z])
                {
                    Instantiate(caveWall, new Vector3(x, 0, z), Quaternion.identity);
                }
                else
                {
                    if (doorPlaced)
                    {
                        Instantiate(caveFloor, new Vector3(x, 0, z), Quaternion.identity);

                    }
                    else
                    {
                        Instantiate(caveEntrance, new Vector3(x, 0, z), Quaternion.identity);
                        doorPlaced = true;
                    }
                    
                }
            }
            
        }
    }

    public bool [,] updateCave()
    {
        bool[,] newCave = new bool[CAVE_DIMENSIONS, CAVE_DIMENSIONS];
        for (int x = 0; x < CAVE_DIMENSIONS; x++)
        {
            for (int z = 0; z < CAVE_DIMENSIONS; z++)
            {
                if (cave[x, z])
                {
                    if (countAliveNeighbours(x, z) < deathLimit)
                    {
                        newCave[x, z] = false;
                    }
                    else
                    {
                        newCave[x, z] = true;
                    }
                }
                else
                {
                    if(countAliveNeighbours(x,z) > birthLimit)
                    {
                        newCave[x, z] = true;
                    }
                    else
                    {
                        newCave[x, z] = false;
                    }
                }
            }
        }
        return newCave;
    }

    public void initialiseCave()
    {
        
        for (int x = 0; x < CAVE_DIMENSIONS; x++)
        {
            for (int z= 0; z< CAVE_DIMENSIONS; z++)
            {
                int randNum = Random.Range(0, 100);
                if (randNum < chanceToStartAlive)
                {
                    
                    cave[x,z] = true;
                }
                else
                {
                    cave[x, z] = false;
                }
            }
        }
    }

    public int countAliveNeighbours(int x, int y)
    {
        int count = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int neighbourx = x + i;
                int neighboury = y + j;
                
            
                if (i == 0 && j == 0)
                {
                    //Do nothing, we don't want to add ourselves in!
                }
                //In case the index we're looking at it off the edge of the map
                else if (neighbourx < 0 || neighboury < 0 || neighbourx >= CAVE_DIMENSIONS -1 || neighboury >= CAVE_DIMENSIONS -1)
                {
                    count = count + 1;
                }
                //Otherwise, a normal check of the neighbour
                else if (cave[neighbourx, neighboury])
                {
                    count = count + 1;
                }
            }
        }
        return count;
    }
    // Update is called once per frame
    void Update () {
		
	}


    void generateCave()
    {
        int direction;
        int count = 0;
        int tempx = caveEntrancex;
        int tmepy = caveEntrancez;
        while (count < caveSize)
        {
            direction = Random.Range(0, 4);
        }

    }



}
