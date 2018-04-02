using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pressButtonToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(loadMenu());
        }
	}

    IEnumerator loadMenu(){
        //yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Menu");
    }
}
