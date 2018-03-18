using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCallback : MonoBehaviour {
    public RPGTalk rpgtalk;
    public RPGTalkArea weatherman;

    void Start()
    {
        rpgtalk.OnMadeChoice += OnMadeChoice;
        rpgtalk.OnEndTalk += OnEndTalk;
        rpgtalk.OnNewTalk += OnNewTalk;
    }

    void OnNewTalk()
    {
        
    }

    void OnEndTalk()
    {

    }

    void OnMadeChoice(int questionID, int choiceID)
    {
        Debug.Log("Aha! In the question " + questionID + " you picked the option " + choiceID);
        
        switch (questionID)
        {
            case 0:
                removeWeathermanTutorialGreeting();
                break;
            case 1:
                dealWithWeathermanTalk(choiceID);
                break;
        }
    }

    private void dealWithWeathermanTalk(int choiceID)
    {
        string option = choiceID.ToString();
        rpgtalk.NewTalk("weatherman-option-" + option + "-picked-start", 
            "weatherman-option-" + option + "-picked-end");
    }

    private void removeWeathermanTutorialGreeting()
    {
        weatherman.lineToStart = "weatherman-default-talk-start";
        weatherman.lineToBreak = "weatherman-default-talk-end";
    }
}
