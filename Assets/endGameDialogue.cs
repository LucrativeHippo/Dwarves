using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameDialogue : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void endGame()
    {
        Debug.Log("sdvsggsgsggsgsgsgsdggdsggssgdsgdgsdgssgd");
        GameObject.Find("Calendar").GetComponent<StormBringer>().resetStorms(50, Weather.weatherTypes.HELLFIRE);

        SceneManager.LoadScene("endGame");
    }
}
