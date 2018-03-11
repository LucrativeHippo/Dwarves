using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cave_generation : MonoBehaviour {

    private int x;
    private int y;
    private int z;

    private int CAVE_HEIGHT = 20;

    private int CAVE_WIDTH = 20;

    private int[,] diggerCave;

    private int caveEntrancex;
    private int caveEntrancey;

    private int caveSize = 150;

	// Use this for initialization
	void Start () {
        diggerCave = new int[CAVE_HEIGHT, CAVE_WIDTH];
        caveEntrancex = Random.Range(1, CAVE_WIDTH -1);
        caveEntrancey = CAVE_HEIGHT - 1;
        for(int i =0; i < CAVE_HEIGHT; i++)
        {
            for(int j =0; j < CAVE_WIDTH; j++)
            {   
                diggerCave[i, j] = 0;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void generateCave()
    {
        int direction;
        int count = 0;
        int tempx = caveEntrancex;
        int tmepy = caveEntrancey;
        while (count < caveSize)
        {
            direction = Random.Range(0, 4);
        }

    }



}
