﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuple
{

    //The two coordinate values on the map
    public float xCoord;
    public float yCoord;


    //Creation function sets both the x and y coordinates
    public Tuple(float x, float y)
    {
        xCoord = x;
        yCoord = y;
    }

    //returns the x coordinate
    public float getxCoord()
    {
        return xCoord;
    }

    //returns the y coordinate
    public float getyCoord()
    {
        return yCoord;
    }

}
