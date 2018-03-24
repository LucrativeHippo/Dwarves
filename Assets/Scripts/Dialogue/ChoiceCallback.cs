using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCallback : MonoBehaviour {
    public RPGTalk rpgtalk;
    public RPGTalkArea weatherman;
    public Calendar calendar;
    
    public GameObject enemy;
    public GameObject sheepMan;

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
            case 9999:
                dealWithForecast(choiceID);
                break;
            case 2:
                penguinInSheepsClothing(choiceID);
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

    private void dealWithForecast(int choiceID)
    {
        switch (choiceID)
        {
            case 0:
                forecastTemperature();
                break;
            case 1:
                forecastWeather();
                break;
        }
    }

    private void forecastTemperature()
    {
        float trendAmount = 0;
        float baseTemp = calendar.getForecastTemp(0);

        for (int i = 1; i < 4 && i < calendar.getDaysToForecast(); i++)
        {
            trendAmount += (calendar.getForecastTemp(i) - baseTemp);
        }

        string trend = "";
        if (trendAmount > 5f)
        {
            trend = "hot";
        }
        else if (trendAmount < -5)
        {
            trend = "cold";
        }
        else
        {
            trend = "neutral";
        }

        rpgtalk.NewTalk("temperature-" + trend + "-forecast-start", 
            "temperature-" + trend + "-forecast-end");
    }

    private void forecastWeather()
    {
        Weather.weatherTypes weatherToForecast = calendar.getForecastWeather(1);

        int endDay = Mathf.Min(4, calendar.getDaysToForecast());
        for (int i = endDay; i > 1; i--)
        {
            if (isDangerousWeather(calendar.getForecastWeather(i)))
            {
                weatherToForecast = calendar.getForecastWeather(i);
            }
        }

        string weatherName = weatherToForecast.ToString();
        weatherName = weatherName.ToLower();
        weatherName = weatherName.Replace("_", "-");

        rpgtalk.NewTalk(weatherName + "-forecast-start", weatherName + "-forecast-end");
    }

    private bool isDangerousWeather(Weather.weatherTypes weather)
    {
        bool dangerous = false;
        switch (weather)
        {
            case Weather.weatherTypes.ACID_RAIN:
                dangerous = true;
                break;
            case Weather.weatherTypes.BLIZZARD:
                dangerous = true;
                break;
            case Weather.weatherTypes.HELLFIRE:
                dangerous = true;
                break;
            case Weather.weatherTypes.SCARY_LIGHTNING:
                dangerous = true;
                break;
        }

        return dangerous;
    }

    private void penguinInSheepsClothing(int choiceID)
    {
        GameObject sheep = GameObject.Find("PenguinInSheepsClothing");
        switch (choiceID)
        {
            
            case 0:
                MetaScript.getRes().addResource(ResourceTypes.FOOD, 10);
                Destroy(sheep);
                break;
            case 1:
                Instantiate(enemy, sheep.transform.position, Quaternion.identity);
                Destroy(sheep);
                break;
            case 2:
                Instantiate(sheepMan, sheep.transform.position, Quaternion.identity);
                Destroy(sheep);
                break;

        }
    }
}
