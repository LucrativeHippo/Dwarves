using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuple<T>
{

    //The two coordinate values on the map
    public T x;
    public T y;


    //Creation function sets both the x and y coordinates
    public Tuple(T x, T y)
    {
		this.x = x;
		this.y = y;
    }

    //returns the x coordinate
    public T getX()
    {
        return x;
    }

    //returns the y coordinate
    public T getY()
    {
        return y;
    }
		
	public override string ToString(){
		return "<Tuple: "+x+" "+y+">";
	}

}
