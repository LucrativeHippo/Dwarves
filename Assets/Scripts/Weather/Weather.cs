using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather: MonoBehaviour
{

    private int weatherTypesCount = 10;

    // These are just INITIAL values, so they're private
    [SerializeField] private int chanceSunny;
    [SerializeField] private int chanceCloudy;
    [SerializeField] private int chanceRain;
    [SerializeField] private int chanceSnow;
    [SerializeField] private int chanceBlizzard;
    [SerializeField] private int chanceHellfire;
    [SerializeField] private int chanceScaryLightning;
    [SerializeField] private int chanceAcidRain;
    [SerializeField] private int chanceSuperHot;
    [SerializeField] private int chancePerfect;

    private Dictionary<weatherTypes, int>  chances = new Dictionary<weatherTypes, int>();

    public enum weatherTypes
    {
        SUNNY,
        CLOUDY,
        RAIN,
        SNOW,
        BLIZZARD,
        HELLFIRE,
        SCARY_LIGHTNING,
        ACID_RAIN,
        SUPER_HOT,
        PERFECT_WEATHER
    }

    public weatherTypes getWeather(float temp)
    {
        int weightedChanceSum = 0;

        QueueDirectAccess<weatherTypes> allowedWeather = new QueueDirectAccess<weatherTypes>();
        allowedWeather.resize(weatherTypesCount);

        allowedWeather.enqueue(weatherTypes.PERFECT_WEATHER);
        weightedChanceSum += chances[weatherTypes.PERFECT_WEATHER];

        allowedWeather.enqueue(weatherTypes.SUNNY);
        weightedChanceSum += chances[weatherTypes.SUNNY];

        allowedWeather.enqueue(weatherTypes.CLOUDY);
        weightedChanceSum += chances[weatherTypes.CLOUDY];

        allowedWeather.enqueue(weatherTypes.SCARY_LIGHTNING);
        weightedChanceSum += chances[weatherTypes.SCARY_LIGHTNING];

        allowedWeather.enqueue(weatherTypes.HELLFIRE);
        weightedChanceSum += chances[weatherTypes.HELLFIRE];

        if (temp >= 20)
        {
            allowedWeather.enqueue(weatherTypes.SUPER_HOT);
            weightedChanceSum += chances[weatherTypes.SUPER_HOT];
        }

        if (temp > 0)
        {
            allowedWeather.enqueue(weatherTypes.RAIN);
            weightedChanceSum += chances[weatherTypes.RAIN];

            allowedWeather.enqueue(weatherTypes.ACID_RAIN);
            weightedChanceSum += chances[weatherTypes.ACID_RAIN];
        }
        else
        {
            allowedWeather.enqueue(weatherTypes.SNOW);
            weightedChanceSum += chances[weatherTypes.SNOW];
        }

        if (temp <= -20)
        {
            allowedWeather.enqueue(weatherTypes.BLIZZARD);
            weightedChanceSum += chances[weatherTypes.BLIZZARD];
        }

        int weatherPick = UnityEngine.Random.Range(0, weightedChanceSum);

        weatherTypes weather = allowedWeather[0];

        while (!allowedWeather.isEmpty() && weatherPick > chances[allowedWeather[0]]) {
            weather = allowedWeather.dequeue();
            weatherPick -= chances[weather];
        }

        if (!allowedWeather.isEmpty())
        {
            weather = allowedWeather.dequeue();
        }


        return weather;
    }

    public void setWeatherChance(weatherTypes weather, int chance)
    {
        if (chance < 0)
        {
            chance = 0;
        }

        chances[weather] = chance;
    }

    public int getWeatherWeightedChance(weatherTypes weather)
    {
        return chances[weather];
    }

    public void changeWeatherChance(weatherTypes weather, int changeAmount)
    {
        chances[weather] += changeAmount;
        if (chances[weather] < 0)
        {
            chances[weather] = 0;
        }
    }

    // Initialization for anything that needs it in "Start"
    void Awake()
    {
        // It feels hack-ish, but doing it like this allows
        // everything after initialization to be cleaner,
        // while also giving a lot of control over start-time
        // values.
        chances[weatherTypes.SUNNY] = chanceSunny;
        chances[weatherTypes.CLOUDY] = chanceCloudy;
        chances[weatherTypes.RAIN] = chanceRain;
        chances[weatherTypes.SNOW] = chanceSnow;
        chances[weatherTypes.BLIZZARD] = chanceBlizzard;
        chances[weatherTypes.HELLFIRE] = chanceHellfire;
        chances[weatherTypes.SCARY_LIGHTNING] = chanceScaryLightning;
        chances[weatherTypes.ACID_RAIN] = chanceAcidRain;
        chances[weatherTypes.SUPER_HOT] = chanceSuperHot;
        chances[weatherTypes.PERFECT_WEATHER] = chancePerfect;
    }

    public void increaseRandomWeatherChance()
    {
        Weather.weatherTypes[] weathers = (Weather.weatherTypes[]) Enum.GetValues(typeof(Weather.weatherTypes));

        int choice = UnityEngine.Random.Range(0, weathers.Length);
        Weather.weatherTypes weatherChoice = weathers[choice];

        chances[weatherChoice] += 1;
    }
}
