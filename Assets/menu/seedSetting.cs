using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class seedSetting : MonoBehaviour {
    private float waterValue = 1.0f;
    private float resourceValue = 1.0f;
    private float terrainValue = 1.0f;

    public Slider waterSlider;
    public Slider resourceSlider;
    public Slider terrainSlider;

	/*//Attempt at fixing default values, did not appear to work, wound up changing start values for now
	void Awake (){
		if (!PlayerPrefs.HasKey("water")){
			waterSlider.value = 1.1f;
		} else {
			PlayerPrefs.GetFloat ("water");
		}
		if (!PlayerPrefs.HasKey("resource")){
			resourceSlider.value = 1.1f;
		} else {
			PlayerPrefs.GetFloat ("resource");
		}
		if (!PlayerPrefs.HasKey("terrain")){
			terrainSlider.value = 1.1f;
		} else {
			PlayerPrefs.GetFloat ("terrain");
		}
	}*/
	// Use this for initialization
	void Start () {
		//waterSlider.value = PlayerPrefs.GetFloat("water");
		//resourceSlider.value = PlayerPrefs.GetFloat("resource");
		//terrainSlider.value = PlayerPrefs.GetFloat("terrain");
        waterSlider.value = 1.15f;
        resourceSlider.value = 1.15f;
        terrainSlider.value = 1.15f;
	}
	
	// Update is called once per frame
	void Update () {
        waterValue = waterSlider.value;
        resourceValue = resourceSlider.value;
        terrainValue = terrainSlider.value;
	}

    //private void setSeed(float water, float resource, float terrain){
    //    PlayerPrefs.SetFloat("water", water);
    //    PlayerPrefs.SetFloat("resource", resource);
    //    PlayerPrefs.SetFloat("terrain", terrain);
    //}

    public void setWater(){
        PlayerPrefs.SetFloat("water", waterValue);
    }

    public void setResource()
    {
        PlayerPrefs.SetFloat("resource", resourceValue);
    }
    public void setTerrain()
    {
        PlayerPrefs.SetFloat("terrain", terrainValue);
    }

}
