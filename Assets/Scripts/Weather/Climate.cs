using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climate : MonoBehaviour
{

    // ************************************
    // Fields
    // ************************************

    private Season[] seasons;

    public float startingTempInCycle;

    public float maxTempAllowed;
    public float minTempAllowed;

    public float maxTempChangePerSeason;
    public float chanceOfTrendInChange;

    public float maxStdDeviation;
    public float minStdDeviation;

    public int seasonsInClimate;
    public int daysPerSeason;

    // ************************************
    // Getters, Setters, and Constructor
    // ************************************

    public void setStartingTempInCycle(float startTemp)
    {
        startingTempInCycle = startTemp;
    }

    public void setMaxTempAllowed(float maxTemp)
    {
        maxTempAllowed = maxTemp;
    }

    public void setMinTempAllowed(float minTemp)
    {
        minTempAllowed = minTemp;
    }

    public void setMaxTempChangePerSeason(float maxChange)
    {
        maxTempChangePerSeason = maxChange;
    }

    public void setChanceOfTrendInChange(float chance)
    {
        chanceOfTrendInChange = chance;
    }

    public void setMaxStdDeviation(float stdDev)
    {
        maxStdDeviation = stdDev;
    }

    public void setMinStdDeviation(float stdDev)
    {
        minStdDeviation = stdDev;
    }

    public void setSeasonsInClimate(int seasonsCount)
    {
        seasonsInClimate = seasonsCount;
    }

    public void setDaysPerSeason(int days)
    {
        daysPerSeason = days;
    }

    public float getStartingTempInCycle()
    {
        return startingTempInCycle;
    }

    public float getMaxTempAllowed()
    {
        return maxTempAllowed;
    }

    public float getMinTempAllowed()
    {
        return minTempAllowed;
    }

    public float getMaxTempChangePerSeason()
    {
        return maxTempChangePerSeason;
    }

    public float getChanceOfTrendInChange()
    {
        return chanceOfTrendInChange;
    }

    public float getMaxStdDeviation()
    {
        return maxStdDeviation;
    }

    public float getMinStdDeviation()
    {
        return minStdDeviation;
    }

    public int getSeasonsInClimate()
    {
        return seasonsInClimate;
    }

    public int getDaysPerSeason()
    {
        return daysPerSeason;
    }

    // ************************************
    // Actual Functionality
    // ************************************

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float getTempFromSeasonAndDay(int season, int day)
    {
        if (season < 0 || season >= seasonsInClimate)
        {
            Debug.LogError("Error: Attempted to get temperature from season that doesn't exist.");
            return 0f;
        }

        if (day < 0 || day >= seasons[season].getDaysInSeason())
        {
            Debug.LogError("Error: Attempted to get temperature from day that doesn't exist in season.");
        }

        float temp = seasons[season].getTemperatureFromDayInSeason(day);
        return temp;
    }

    public void generateNewClimate()
    {
        errorCheckPublicValues();

        seasons = new Season[seasonsInClimate];

        for (int i = 0; i < seasonsInClimate; i++)
        {
            seasons[i] = new Season();
            seasons[i].setDaysInSeason(daysPerSeason);

            float startTemp = generateNewSeasonStartingTemp(i);
            float endTemp = generateNewSeasonEndingTemp(i, startTemp);
            generateNewSeasonMidTemp(i, startTemp, endTemp);
            generateNewStdDeviationTemp(i);
        }
    }

    private float generateNewSeasonStartingTemp(int season)
    {
        float startTemp;

        // In order to give more control over the generation,
        // the first season's starting temp is provided
        if (season == 0)
        {
            startTemp = startingTempInCycle;
        }
        else
        {
            startTemp = seasons[season - 1].getEndingMeanTemp();
        }
        startTemp = Mathf.Clamp(startTemp, minTempAllowed, maxTempAllowed);
        seasons[season].setBeginningMeanTemp(startTemp);

        return startTemp;
    }

    private float generateNewSeasonMidTemp(int season, float startTemp, float endTemp)
    {
        // We don't want any weird seasons where the end mean is above the starting
        // mean by the maximum change allowed, and yet the season's mid mean is
        // as far below the starting mean as the maximum change allows.
        //
        // It should be contained in a semi-sane manner.
        float maxMidTemp = System.Math.Min(startTemp + maxTempChangePerSeason,
                endTemp + maxTempChangePerSeason);
        float minMidTemp = System.Math.Max(startTemp - maxTempChangePerSeason,
            endTemp - maxTempChangePerSeason);

        maxMidTemp = Mathf.Clamp(maxMidTemp, minTempAllowed, maxTempAllowed);
        minMidTemp = Mathf.Clamp(minMidTemp, minTempAllowed, maxTempAllowed);

        float midTemp = Random.Range(minMidTemp, maxMidTemp);
        seasons[season].setMiddleMeanTemp(midTemp);

        return midTemp;
    }

    private float generateNewSeasonEndingTemp(int season, float startTemp)
    {
        float endTemp;

        // Since this is a cycle, the final season should have an ending mean 
        // temperature that's the same as the first season's starting mean.
        if (season == seasonsInClimate - 1)
        {
            endTemp = seasons[0].getBeginningMeanTemp();
        }
        else
        {
            float minRange = Mathf.Max(startTemp - maxTempChangePerSeason, minTempAllowed);
            float maxRange = Mathf.Min(startTemp + maxTempChangePerSeason, maxTempAllowed);
            endTemp = Random.Range(minRange, maxRange);
        }
        endTemp = Mathf.Clamp(endTemp, minTempAllowed, maxTempAllowed);
        seasons[season].setEndingMeanTemp(endTemp);

        // Possibly force the change in temperature to be in the same direction as last season.
        if (season > 0 && Random.Range(0, 100) <= chanceOfTrendInChange
            && startTemp != minTempAllowed && startTemp != maxTempAllowed)
        {
            endTemp = forceTemperatureTrend(season, endTemp);
        }

        // We want to make sure we don't need to change any season's temperature more
        // than the allowed amount. So, we have to account for ending the cycle where it started.
        endTemp = clampTemperatureForCycleRepeat(season);

        return endTemp;
    }

    private float forceTemperatureTrend(int season, float endTemp)
    {
        if (season < 1 || season > seasonsInClimate - 1)
        {
            Debug.LogError("Error: attempted to force a trend in climate when no trend possible.");
            return endTemp;
        }

        float lastTrend = seasons[season - 1].getTemperatureTrend();
        float currentTrend = seasons[season].getTemperatureTrend();

        if (lastTrend != currentTrend)
        {
            float oldChange = endTemp - seasons[season].getBeginningMeanTemp();
            endTemp = seasons[season].getBeginningMeanTemp() + (oldChange * -1);
        }
        seasons[season].setEndingMeanTemp(endTemp);

        return endTemp;
    }

    // Since the final season should have an ending mean equal to the first
    // season's starting mean, we have to make sure that no seasons further
    // down the line would need an ending mean that differs from it's starting
    // mean by more than the maximum allowed change per season.
    private float clampTemperatureForCycleRepeat(int season)
    {
        float endTemp = seasons[season].getEndingMeanTemp();

        int seasonsLeft = seasonsInClimate - season - 1;
        float cycleEndTemp = seasons[0].getBeginningMeanTemp();
        float changePossible = seasonsLeft * maxTempChangePerSeason;
        endTemp = Mathf.Clamp(endTemp, cycleEndTemp - changePossible, cycleEndTemp + changePossible);

        seasons[season].setEndingMeanTemp(endTemp);

        return endTemp;
    }

    private float generateNewStdDeviationTemp(int season)
    {
        float stdDev = Random.Range(minStdDeviation, maxStdDeviation);
        seasons[season].setStdDeviationTemp(stdDev);

        return stdDev;
    }

    // A quick sanity check on all public values set in the editor
    private void errorCheckPublicValues()
    {
        if (minTempAllowed > maxTempAllowed)
        {
            float tmp = minTempAllowed;
            minTempAllowed = maxTempAllowed;
            maxTempAllowed = tmp;

            Debug.LogError("Error: During climate generation, the min temp was " +
                "higher than the max temp. Values were swapped, but this may be worth " +
                "looking into.");
        }

        if (startingTempInCycle > maxTempAllowed 
            || startingTempInCycle < minTempAllowed)
        {
            startingTempInCycle = (minTempAllowed + maxTempAllowed) / 2;

            Debug.LogError("Error: During climate generation, the starting temp was " +
                "set to outside the allowed temperature range. Starting temp was set to " +
                "the average of the range boundaries to attempt recovery.");
        }

        if (maxTempChangePerSeason < 0)
        {
            maxTempChangePerSeason = Mathf.Abs(maxTempChangePerSeason);

            Debug.LogError("Error: During climate generation, the maximum change " +
                "in temp per season was negative. Value was recovered, but this may be worth " +
               "looking into.");
        }

        if (chanceOfTrendInChange < 0)
        {
            chanceOfTrendInChange = 0;

            Debug.LogError("Error: During climate generation, there was a negative chance for " +
                "a temperature trend. We've set it to 0 for now to recover.");
        }

        if (chanceOfTrendInChange > 100)
        {
            chanceOfTrendInChange = 100;

            Debug.LogError("Error: During climate generation, there was a greater than 100% chance " +
                "for a temperature trend. We've set it to 100 for now to recover.");
        }

        if (minStdDeviation > maxStdDeviation)
        {
            float tmp = minStdDeviation;
            minStdDeviation = maxStdDeviation;
            maxStdDeviation = tmp;

            Debug.LogError("Error: During climate generation, the min stdDev was " +
                "higher than the max stdDev. Values were swapped, but this may be worth " +
                "looking into.");
        }

        if (seasonsInClimate < 1)
        {
            seasonsInClimate = 1;

            Debug.LogError("Error: During climate generation, the climate was set to have " +
                "fewer than 1 season. We've set it to 1 for now to recover.");
        }

        if (daysPerSeason < 1)
        {
            daysPerSeason = 1;

            Debug.LogError("Error: During climate generation, each season was set to have " +
                "fewer than 1 day. We've set it to 1 for now to recover.");
        }
    }
}

