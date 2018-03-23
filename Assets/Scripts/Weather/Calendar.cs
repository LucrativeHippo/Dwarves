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
    private Weather weather;
    private QueueDirectAccess<float> forecastTemp;
    private QueueDirectAccess<Weather.weatherTypes> forecastWeather;


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

    public  int getCurrentDay()
    {
        return currentDay+1;
    }
   
    public int getCurrentYear()
    {
        return currentYear;
    }

    public int getCurrentSeason()
    {
        return currentSeason;
    }

   

    public int getDaysToForecast()
    {
        return daysToForecast;
    }

    public float getForecastTemp(int day)
    {
        if (day < 0)
        {
            Debug.LogError("Attempted to get forecast of a day less than zero. " +
                "Attempting to recover by setting to current day.");
            return forecastTemp[0];
        }
        if (day > daysToForecast - 1)
        {
            Debug.LogError("Attempted to get forecast of a day outside forecast. " +
                "Attempting to recover by setting to last day in forecast.");
            return forecastTemp[daysToForecast - 1];
        }

        return forecastTemp[day];
    }

    public Weather.weatherTypes getForecastWeather(int day)
    {
        if (day < 0)
        {
            Debug.LogError("Attempted to get forecast of a day less than zero. " +
                "Attempting to recover by setting to current day.");
            return forecastWeather[0];
        }
        if (day > daysToForecast - 1)
        {
            Debug.LogError("Attempted to get forecast of a day outside forecast. " +
                "Attempting to recover by setting to last day in forecast.");
            return forecastWeather[daysToForecast - 1];
        }

        return forecastWeather[day];
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
            generateNewTempForecast();
        }

        weather = gameObject.GetComponent<Weather>();
        if (weather == null)
        {
            Debug.LogError("Error: No Weather script attached to Calendar object.");
        }
        else
        {
            generateNewWeatherForecast();
        }

        /*for (int i = 0; i < daysToForecast; i++)
        {
            Debug.Log(forecastTemp[i] + " : " + forecastWeather[i]);
        }*/
    }

    public int getDaysPerSeason()
    {
        return climate.getDaysPerSeason();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void generateNewWeatherForecast()
    {
        forecastWeather = new QueueDirectAccess<Weather.weatherTypes>();
        forecastWeather.resize(daysToForecast);

        if (forecastTemp == null)
        {
            Debug.LogError("Error: Can't generate a weather forecast before temperature.");
            return;
        }
        else if (forecastTemp.getSize() != daysToForecast)
        {
            Debug.LogError("Error: Size mismatch. Generate new temperature forecast before weather.");
            return;
        }

        for (int i = 0; i < daysToForecast; i++)
        {
            forecastWeather.enqueue(weather.getWeather(forecastTemp[i]));
        }
    }

    public void generateNewTempForecast()
    {
        forecastTemp = new QueueDirectAccess<float>();
        forecastTemp.resize(daysToForecast);

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
            forecastTemp.enqueue(temperature);

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
        forecastTemp.dequeue();
        forecastTemp.enqueue(temp);

        forecastWeather.dequeue();
        forecastWeather.enqueue(weather.getWeather(temp));
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
