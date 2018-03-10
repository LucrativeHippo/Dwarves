using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {
	public GameObject canvas;
	UnityEngine.UI.Text speech;
	UnityEngine.UI.Image bubble;
	Animator anim;
	public bool startDisplay;
	public bool endDisplay;
	// Use this for initialization
	void Start () {
		speech = canvas.GetComponentInChildren<UnityEngine.UI.Text>();
		bubble = canvas.GetComponentInChildren<UnityEngine.UI.Image>();
		anim = canvas.GetComponentInChildren<Animator>();
		startDisplay = false;
		endDisplay = false;
		clearText();
	}
	
	// Update is called once per frame
	void Update () {
		if(startDisplay){
			speech.text = myText;
		// }else if(bubble.enabled && !isDisplayed){
		// 	clearText();
		}

		if(endDisplay){
			clearText();
		}
	}
	private string myText;
	public void setText(string text){
		bubble.enabled = true;
		anim.SetTrigger("Thinking");
		myText = text;
	}

	public void clearText(){
		speech.text = "";
		bubble.enabled = false;
		endDisplay = false;
	}
}
