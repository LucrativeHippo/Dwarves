using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour {

    // ************************************
    // Fields
    // ************************************

    public int currentYear;
    public int currentSeason;
    public int currentDay;

    public int daysToForecast;
    private Climate climate;
    private QueueDirectAccess<float> forecast;


    // ************************************
    // Getters, Setters, and Constructor
    // ************************************

    public void setCurrentYear(int year)
    {
        currentYear = year;
    }

    public void setCurrentSeason(int season)
    {
        currentSeason = season;
    }

    public void setCurrentDay(int day)
    {
        currentDay = day;
    }

    public int getCurrentYear()
    {
        return currentYear;
    }

    public int getCurrentSeason()
    {
        return currentSeason;
    }

    public int getCurrentDay()
    {
        return currentDay;
    }


    // ************************************
    // Actual Functionality
    // ************************************

    // Use this for initialization
    void Start () {
        climate = gameObject.GetComponent<Climate>();
        if (climate == null)
        {
            Debug.LogError("Error: No Climate script attached to Calendar object.");
        }
        else
        {
            climate.generateNewClimate();
            generateNewForecast();
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void generateNewForecast()
    {
        forecast = new QueueDirectAccess<float>();
        //forecast.resize(daysToForecast);

        int daysInSeasons = climate.getDaysPerSeason();
        int seasonsInClimate = climate.getSeasonsInClimate();

        int dayInForecast = currentDay;
        int seasonInForecast = currentSeason;

        for (int i = 0; i < daysToForecast; i++)
        {
            if (dayInForecast == daysInSeasons)
            {
                dayInForecast = 0;
                seasonInForecast++;

                if (seasonInForecast == seasonsInClimate)
                {
                    seasonInForecast = 0;
                }
            }

            float temperature = climate.getTempFromSeasonAndDay(seasonInForecast, dayInForecast);
            forecast.enqueue(temperature);

            dayInForecast++;
        }
    }

    private void updateForecastAfterDayWasAdvanced()
    {
        // If each individual season ever gets the option of having
        // a unique number of days, this will need to be updated.
        // As it is, we can "1, 2, skip a few, 99, 100" with this.
        int daysPerSeason = climate.getDaysPerSeason();
        int climateCount = climate.getSeasonsInClimate();

        int seasonsToAdvance = daysToForecast / daysPerSeason;

        int seasonToForecast = (currentSeason + seasonsToAdvance) % climateCount;
        int dayToForecast = currentDay + daysToForecast - (seasonsToAdvance * daysPerSeason);

        if (dayToForecast >= daysPerSeason)
        {
            dayToForecast -= daysPerSeason;
            seasonToForecast++;

            if (seasonToForecast == climateCount)
            {
                seasonToForecast = 0;
            }
        }

        float temp = climate.getTempFromSeasonAndDay(seasonToForecast, dayToForecast);

        // Dequeue before enqueue means we won't trigger a queue resize.
        forecast.dequeue();
        forecast.enqueue(temp);
    }


    public void toNextDay()
    {
        currentDay++;
        int daysInSeason = climate.getDaysPerSeason();

        if (currentDay == daysInSeason)
        {
            toNextSeason();
        }
        else if (currentDay > daysInSeason)
        {
            Debug.LogError("Error: Calendar days somehow overflowed.");
            toNextSeason();
        }

        updateForecastAfterDayWasAdvanced();
    }

    public void toNextSeason()
    {
        currentDay = 0;
        currentSeason++;

        int seasonsInClimate = climate.getSeasonsInClimate();
        if (currentSeason == seasonsInClimate)
        {
            toNextYear();
        }
        else if (currentSeason > seasonsInClimate)
        {
            Debug.LogError("Error: Calendar seasons somehow overflowed.");
            toNextYear();
        }
    }

    public void toNextYear()
    {
        currentDay = 0;
        currentSeason = 0;
        currentYear++;

        // This function can technically overflow here.
        // However, for the moment it's safe to assume nobody will play
        // for an int overflow number of years. The UI will probably die first.
        //
        // We'll patch this if and when it's needed.
    }
}
