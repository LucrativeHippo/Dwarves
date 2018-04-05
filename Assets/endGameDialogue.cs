using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameDialogue : MonoBehaviour {

    [SerializeField]
    private GameObject anagram;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void endGame()
    {
        GameObject.FindGameObjectWithTag("Wonder").GetComponent<endGameWonder>().enabled = true;
        
    }

    
}
