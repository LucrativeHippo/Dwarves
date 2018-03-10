using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volume : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<AudioSource>().volume=PlayerPrefs.GetFloat("musicvolume");

        Debug.Log(this.GetComponent<AudioSource>().volume);
	}
	
	// Update is called once per frame
	 void  Update () {
        
        this.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicvolume");
        //Debug.Log(this.GetComponent<AudioSource>().volume );
	}
}
