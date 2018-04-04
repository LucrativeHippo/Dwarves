using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinking : MonoBehaviour
{
    public Text theText;
    public GameObject t;

    void Start()
    {
        this.theText = t.GetComponent<Text>();
        //Call coroutine BlinkText on Start
        StartCoroutine(BlinkText());

    }

    public IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement
        while (true)
        {
            //set the Text's text to blank
            theText.color = new Color(150f / 255.0f, 34f / 255.0f, 34f / 255.0f);
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(1.5f);
            //display “I AM FLASHING TEXT” for the next 0.5 seconds
            theText.color = Color.black;
            yield return new WaitForSeconds(0.927f);
        }
    }
}

