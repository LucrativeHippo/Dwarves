using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour {
    public GameObject continuebt;
    public GameObject newgamebt;
    public GameObject loadgamebt;
    public Animator objects;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
public void playoption(){
        continuebt.SetActive(true);
        newgamebt.SetActive(true);
        loadgamebt.SetActive(true);
    }

    public void closeplayoption()
    {
        continuebt.SetActive(false);
        newgamebt.SetActive(false);
        loadgamebt.SetActive(false);
    }

    public void position1()
    {
        objects.SetFloat("animate",0);
    }
    public void position2(){
        closeplayoption();
        objects.SetFloat("animate",1);

    }

}
