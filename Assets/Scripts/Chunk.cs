using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Chunk contains full map of an area.
/// Included is terrain, objects, NPC, buildings,...
/// </summary>
public class Chunk{
	/// Size of a section side generated for the map
	public const int SIZE = 100;
	/// The map.
	protected GameObject[,] map;

	/// <summary>
	/// Initializes a new instance of the <see cref="Chunk"/> class.
	/// </summary>
	public Chunk(){
		map = new GameObject[SIZE, SIZE];
	}


	/// <summary>
	/// Adds the tile g at x and y.
	/// </summary>
	/// <param name="g">The gameobject tile.</param>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public void addTileAt(GameObject g, int x, int y){
		map [x, y] = g;
	}
}
