using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Chunk contains full map of an area.
/// Included is terrain, objects, NPC, buildings,...
/// </summary>
public class Chunk{
	/// Size of a section side generated for the map
	public const int SIZE = 5;

    public const int LAYERS = 3; 
	/// The map.
	protected GameObject[,,] map;

	/// <summary>
	/// Initializes a new instance of the <see cref="Chunk"/> class.
	/// </summary>
	public Chunk(){
		map = new GameObject[SIZE, SIZE, LAYERS];
	}


	/// <summary>
	/// Adds the tile g at x and y.
	/// </summary>
	/// <param name="g">The gameobject tile.</param>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	public void addTileAt(GameObject g, int x, int y, int z){
		map [x, y, z] = g;
	}
	public static Vector3Int getChunkPos(Vector3 pos){
		return Vector3Int.FloorToInt(pos/(float)SIZE);
	}
	public static Vector3Int getRoundChunkPos(Vector3 pos){
		return Vector3Int.RoundToInt(pos/(float)SIZE);
	}

	public static string getChunkKey(Vector3 worldPos){
		return getChunkKey(getChunkPos(worldPos));
	}
	public static string getChunkKey(Vector3Int chunkPos){
		return chunkPos.x + " " + chunkPos.z;
	}
}
