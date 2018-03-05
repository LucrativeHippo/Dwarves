using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volume : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<AudioSource>().volume=PlayerPrefs.GetFloat("musicvolume");	
	}
	
	// Update is called once per frame
	public void  Updatev () {
        this.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicvolume");
	}
}
