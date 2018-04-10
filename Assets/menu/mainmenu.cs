using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainmenu : MonoBehaviour {
  
    public GameObject newgamebt;
    public Animator objects;
    public GameObject clicksound;
    public GameObject particlesystem;
    public GameObject positionsforplay;
    public GameObject positionsforsetting;
    public GameObject positionsforreturn;

    [SerializeField] private GameObject controlsCanvas;
    [SerializeField] private GameObject settingsCanvas;

public void playoption(){
       
        newgamebt.SetActive(true);
       
    }

    public void closeplayoption()
    {

        newgamebt.SetActive(false);
       
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
        settingsCanvas.SetActive (true);
        controlsCanvas.SetActive (false);
        closeplayoption();
        objects.SetFloat("animate",1);
    }

    public void position3() {
        controlsCanvas.SetActive (true);
        settingsCanvas.SetActive (false);
        closeplayoption ();
        objects.SetFloat ("animate", 1);
    }
    
    public void quitgame(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_STANDALONE
        Application.Quit();
#endif

    }
    public void PlayClick()
    {
        clicksound.GetComponent< AudioSource > ().Play();
    }
    //public void fixslider(){
    //    sliderVal = GUI.HorizontalSlider(slider, sliderVal, 0.0, levelPoints);


    //}

}
