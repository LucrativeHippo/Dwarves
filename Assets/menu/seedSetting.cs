using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedSetting : MonoBehaviour {
    public float waterSeed = 1.0f;
    public float resourceSeed = 1.0f;
    public float terrainSeed = 1.0f;

	// Use this for initialization
	void Start () {
        setSeed(waterSeed, resourceSeed, terrainSeed);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void setSeed(float water, float resource, float terrain){
        PlayerPrefs.SetFloat("water", water);
        PlayerPrefs.SetFloat("resource", resource);
        PlayerPrefs.SetFloat("terrain", terrain);
    }
}
