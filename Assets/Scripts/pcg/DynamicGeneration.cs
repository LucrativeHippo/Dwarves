using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGeneration : MonoBehaviour {
	public terrainGenerator generator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = gameObject.transform.position  / (float)Chunk.SIZE;
		
			for(int i = -1; i < 2; i++)
			{
				for(int j = -1; j < 2; j++)
				{
					generator.generateChunk(Mathf.RoundToInt(pos.x) + i, Mathf.RoundToInt(pos.z) + j);
				}
			}
	}
}
