using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {
	public GameObject canvas;
	UnityEngine.UI.Text speech;
	UnityEngine.UI.Image bubble;
	// Use this for initialization
	void Start () {
		speech = canvas.GetComponentInChildren<UnityEngine.UI.Text>();
		bubble = canvas.GetComponentInChildren<UnityEngine.UI.Image>();

		clearText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setText(string text){
		bubble.enabled = true;
		speech.text = text;

		Invoke("clearText",4);
	}

	public void clearText(){
		setText("");
		bubble.enabled = false;
		
	}
}
