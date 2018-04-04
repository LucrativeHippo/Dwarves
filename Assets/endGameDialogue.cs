using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameDialogue : MonoBehaviour {

	// Use this for initialization
	void Start () {
        RPGTalk rpgtalk = gameObject.GetComponent<RPGTalk>();

        rpgtalk.NewTalk("endgame-default-talk-start", "endgame-default-talk-end");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
