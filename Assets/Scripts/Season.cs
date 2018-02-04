using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Season {

    // ************************************
    // Fields
    // ************************************

    // Having 3 different mean temps allows each season to follow a "curve".
    // This means we can smoothly transition between each season fairly easily.
    private float beginningMeanTemp;
    private float middleMeanTemp;
    private float endingMeanTemp;

    // Allows us to control how far away from the season's temperature curve the
    // current temperature is allowed to go.
    private float stdDeviationTemp;

    // After this many days have passed, the season should be over.
    // Also allows us to calculate where we are on the temperature curve.
    private int daysInSeason;


    // ************************************
    // Getters, Setters, and Constructor
    // ************************************

    public void setBeginningMeanTemp(float temp)
    {
        beginningMeanTemp = temp;
    }

    public void setMiddleMeanTemp(float temp)
    {
        middleMeanTemp = temp;
    }

    public void setEndingMeanTemp(float temp)
    {
        endingMeanTemp = temp;
    }

    public void setStdDeviationTemp(float stdDeviation)
    {
        stdDeviationTemp = stdDeviation;
    }

    public void setDaysInSeason(int days)
    {
        daysInSeason = days;
        if (daysInSeason < 1)
        {
            daysInSeason = 1;
        }
    }

    public float getBeginningMeanTemp()
    {
        return beginningMeanTemp;
    }

    public float getMiddleMeanTemp()
    {
        return middleMeanTemp;
    }

    public float getEndingMeanTemp()
    {
        return endingMeanTemp;
    }

    public float getStdDeviationTemp()
    {
        return stdDeviationTemp;
    }

    public int getDaysInSeason()
    {
        return daysInSeason;
    }


    // ************************************
    // Actual Functionality
    // ************************************

    public float getTemperatureTrend()
    {
        return Mathf.Sign(beginningMeanTemp - endingMeanTemp);
    }

    // Uses the standard deviation and mean temperature to randomly generate a 
    // new current temperature. Since it is random, a new value is generated on 
    // every call.
    public float getTemperatureFromDayInSeason(int day)
    {
        errorCheckDayInRange(day, "getTemperatureFromDayInSeason");

        float randomFloat1 = Random.Range(0.0f, 1.0f);
        float randomFloat2 = Random.Range(0.0f, 1.0f);

        return internalGetCurrTempFromDay(day, randomFloat1, randomFloat2);
    }

    // An incredibly quick-and-dirty implementation of the Box-Muller transform
    // for easy random numbers from a normal distribution.
    //
    // The actual logic is separate from the public call so that the random numbers can be
    // manually passed into the function. This makes testing the function possible.
    private float internalGetCurrTempFromDay(int day, float randomFloat1, float randomFloat2)
    {
        errorCheckDayInRange(day, "internalSetCurrTempFromDay");

        float mean = getMeanTempOfDay(day);

        // Log(x) breaks horribly if x is equal to or less than zero, and floating point 
        // random number functions seem to only be [inclusive] of both ends.
        if (randomFloat1 <= 0)
        {
            randomFloat1 = 0.000000001f;
        }

        float weightOfDeviation = (float)System.Math.Sqrt(-2.0 * System.Math.Log(randomFloat1)) *
            (float)System.Math.Sin(2.0 * System.Math.PI * randomFloat2);

        float randomFromNormal = weightOfDeviation * stdDeviationTemp + mean;
        return randomFromNormal;
    }


    // Currently uses a linear relation from start to middle of season, followed
    // by another linear relation from middle of season to end of season.
    //
    // It's not technically a "curve", but the player is unlikely to notice.
    // If they do, we likely have bigger problems.
    public float getMeanTempOfDay(int day)
    {
        errorCheckDayInRange(day, "getMeanTempOfDay");

        float seasonCompletion = (float)day / (float)daysInSeason;

        float startOfRange;
        float endOfRange;
        float valueInRange;

        if (seasonCompletion < 0.5)
        {
            startOfRange = beginningMeanTemp;
            endOfRange = middleMeanTemp;
            valueInRange = seasonCompletion * 2;
        }
        else
        {
            startOfRange = middleMeanTemp;
            endOfRange = endingMeanTemp;
            valueInRange = (seasonCompletion - 0.5f) * 2;
        }

        float mean = valueInRange * (endOfRange - startOfRange) + startOfRange;
        return mean;
    }

    private float errorCheckDayInRange(int day, string functionName)
    {
        // Simple error checking. Still undecided what we should do
        // to recover from an nonsense input error.
        if (day < 0)
        {
            day = 0;
            Debug.LogError("Error: " + functionName + " input day was less than 0.");
        }
        else if (day >= daysInSeason)
        {
            day = daysInSeason - 1;
            Debug.LogError("Error: " + functionName + " input day " +
                "was greater than or equal to the days in the season. " +
                "The days are indexed starting from 0.");
        }

        return day;
    }
}
