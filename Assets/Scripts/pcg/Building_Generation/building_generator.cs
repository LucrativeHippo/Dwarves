using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building_generator {

    private static int MAX_WIDTH = 16;
    private static int MAX_HEIGHT = 16;
    private static int MIN_WIDTH = 8;
    private static int MIN_HEIGHT = 8;
    private static int DEPTH = -40;
    private bool doorPlaced = false;


    //building stats
    private int width;
    private int height;
    private int xlocation;
    private int zlocation;
    private int ylocation;
    private int doorxlocation;
    private int doorzlocation;


    //Getters and Setters
    public int getxlocation()
    {
        return xlocation;
    }

    public int getylocation()
    {
        return ylocation;
    }

    public int getzlocation()
    {
        return zlocation;
    }

    public int getdoorxlocation()
    {
        return doorxlocation;
    }

    public int getdoorzlocation()
    {
        return doorzlocation;
    }

    public int getwidth()
    {
        return width;
    }

    public int getheight()
    {
        return height;
    }
    //The basic building construcot function
    public building_generator(int xpos, int zpos, int ypos, GameObject parentBuilding, GameObject wall, GameObject door, GameObject floor)
    {
        width = Random.Range(MIN_WIDTH, MAX_WIDTH);
        height = Random.Range(MIN_HEIGHT, MAX_HEIGHT);

        xlocation = xpos * MAX_WIDTH;
        zlocation = zpos * MAX_HEIGHT;
        ylocation = ypos + DEPTH;

        doorxlocation = width/2;
        doorzlocation = height-1;

        GameObject Building = new GameObject("Building: " + xlocation + " " + ylocation);
        Building.transform.SetPositionAndRotation(new Vector3(xlocation, 0, zlocation), Quaternion.identity);


        for (int i= 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(i ==0 || j == 0 || i == height-1 || j == width-1)
                {
                    if(j == width/2 && i == height -1 )
                    {
                        
                        GameObject temp = GameObject.Instantiate(door, new Vector3(xlocation + j, ylocation, zlocation + i), Quaternion.identity);
                        var rot = temp.transform.rotation;
                        rot.x = 1;
                        temp.transform.rotation = rot;
                        temp.transform.SetParent(Building.transform);
                        doorPlaced = true;
                    }
                    else
                    {
                        GameObject temp = GameObject.Instantiate(wall, new Vector3(xlocation + j, ylocation, zlocation + i), Quaternion.identity);
                        var rot = temp.transform.rotation;
                        rot.x = 1;
                        temp.transform.rotation = rot;
                        temp.transform.SetParent(Building.transform);

                    }
                }
                else
                {
                    GameObject temp = GameObject.Instantiate(floor, new Vector3(xlocation + j, ylocation, zlocation + i), Quaternion.identity);
                    var rot = temp.transform.rotation;
                    rot.x = 1;
                    temp.transform.rotation = rot;
                    temp.transform.SetParent(Building.transform);

                }
            }
        }
    }
	
}
