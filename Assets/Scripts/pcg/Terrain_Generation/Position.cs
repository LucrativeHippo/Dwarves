using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{

    //The two coordinate values on the map
    public int xCoord;
    public int yCoord;


    //Creation function sets both the x and y coordinates
    public Position(int x,int y)
    {
        xCoord = x;
        yCoord = y;
    }

    //returns the x coordinate
    public int getxCoord()
    {
        return xCoord;
    }

    //returns the y coordinate
    public int getyCoord()
    {
        return yCoord;
    }

}
