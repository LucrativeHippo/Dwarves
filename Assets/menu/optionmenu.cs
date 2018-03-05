using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionmenu : MonoBehaviour {
    private float sliderValue = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Musics()
    {
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
