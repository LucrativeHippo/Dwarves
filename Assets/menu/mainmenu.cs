using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour {
    public GameObject continuebt;
    public GameObject newgamebt;
    public GameObject loadgamebt;
    public Animator objects;
    public GameObject clicksound;
    public GameObject particlesystem;
    public GameObject positionsforplay;
    public GameObject positionsforsetting;
    public GameObject positionsforreturn;
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
    public void openparticle(){
        
        Instantiate(particlesystem, positionsforplay.transform.position, Quaternion.identity);
    }
    public void openparticlesetting()
    {

        Instantiate(particlesystem, positionsforsetting.transform.position, Quaternion.identity);
    }
    public void openparticleforreturn()
    {

        Instantiate(particlesystem, positionsforreturn.transform.position, Quaternion.identity);
    }

    public void position1()
    {
        objects.SetFloat("animate",0);
    }
    public void position2(){
        closeplayoption();
        objects.SetFloat("animate",1);

    }
    public void quitgame(){
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();



    }
    public void PlayClick()
    {
        clicksound.GetComponent< AudioSource > ().Play();
    }
    //public void fixslider(){
    //    sliderVal = GUI.HorizontalSlider(slider, sliderVal, 0.0, levelPoints);


    //}

}
