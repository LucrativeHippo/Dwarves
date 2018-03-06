using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class optionmenu : MonoBehaviour {
    private float sliderValue;
   
    public Slider sliderval;
	// Use this for initialization
	void Start () {
        sliderval.value = PlayerPrefs.GetFloat("musicvolume");
	}
	
	// Update is called once per frame
	void Update () {
        
        sliderValue = sliderval.value;
       
        //Debug.Log("musicvolume");
	}
    public void Musics()
    {
        PlayerPrefs.SetFloat("musicvolume", sliderValue);
    }
}
