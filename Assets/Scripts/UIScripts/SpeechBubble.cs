using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {
	public GameObject canvas;
	UnityEngine.UI.Text speech;
	UnityEngine.UI.Image bubble;
	Animator anim;
	public bool showDisplay;
	public bool showText;
	// Use this for initialization
	void Start () {
		speech = canvas.GetComponentInChildren<UnityEngine.UI.Text>();
		bubble = canvas.GetComponentInChildren<UnityEngine.UI.Image>();
		anim = canvas.GetComponentInChildren<Animator>();
		showDisplay = false;
		showText = false;
		clearText();
	}
	
	// Update is called once per frame
	void Update () {
		if(showDisplay){
			bubble.enabled = true;
			if(showText){
				speech.text = myText;
			}else{
				clearText();
			}
		}else{
			bubble.enabled = false;
			clearText();
		}
	}
	private string myText;
	public void setText(string text){
		showDisplay = true;
		anim.SetTrigger("Thinking");
		myText = text;
	}

	public void clearText(){
		speech.text = "";
	}
}
