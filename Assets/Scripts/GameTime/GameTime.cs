using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class GameTime : MonoBehaviour
{

    public float dayTime = 300.0f;
    private Calendar calendar;
    private GameObject calendarObject;
    private Weather weatherScript;
    public Slider daychange;
    public Text daychangetext;
    public Text seasonchange;
    private GenerateMonster generateMonster;
    private GameObject UIObject;
    private UseCustomImageEffect postProcessing;
    private StormBringer stormBringer;
    private float timevalue;
    //Change the number of days before a bad weather increase chance
    public int gracePeriod = 7;


    void Start()
    {
        UIObject = GameObject.Find("UIController");

        GameObject temp = GameObject.Find("monster_generator");
        weatherScript = gameObject.GetComponent<Weather>();
        calendar = gameObject.GetComponent<Calendar>();
        generateMonster = temp.GetComponent<GenerateMonster> ();
        stormBringer = gameObject.GetComponent<StormBringer>();
        postProcessing = GameObject.FindObjectOfType<UseCustomImageEffect>();
        daychange = GameObject.Find("daychange").GetComponent<Slider>();
        daychangetext = GameObject.Find("totalday").GetComponent<Text>();
        seasonchange = GameObject.Find("seasontext").GetComponent<Text>();

        calendar.generateNewWeatherSystem();
        stormBringer.initializeInternals();

        IEnumerator co = Timer(dayTime);
        StartCoroutine(co);

        initializeCalendarUI();
        updateTimedEffects();
    }


    private void Update()
    {
        float seasonProgress = daychange.value;
        seasonProgress += (Time.deltaTime / dayTime);
        daychange.value = seasonProgress;
    }

    private void initializeCalendarUI()
    {
        int daysPerSeason = calendar.getDaysPerSeason();
        daychange.maxValue = daysPerSeason;
        daychange.minValue = 0;
        daychange.value = 0;
    }


    private void setWeatherBasedPostProcessing()
    {
        if (postProcessing != null && calendar != null)
        {
            // Setting the saturation value at 0 when -40, 2 at +40
            float adjustedTemp = calendar.getForecastTemp(0) + 40;
            float satVal = adjustedTemp / 40;
            satVal = Mathf.Clamp(satVal, 0, 2);

            postProcessing.setSaturationValue(satVal);
            if (calendar.getForecastTemp(0) > 30)
            {
                postProcessing.setDisplaceAmount(0.004f);
                postProcessing.setDoDisplacement(true);
            }
            else if (calendar.getForecastTemp(0) > 20)
            {
                postProcessing.setDisplaceAmount(0.002f);
                postProcessing.setDoDisplacement(true);
            }
            else
            {
                postProcessing.setDoDisplacement(false);
            }
        }
    }

    private void setWeatherBasedParticles()
    {
        Weather.weatherTypes weather = calendar.getForecastWeather(0);
        WeatherVisuals visuals = gameObject.GetComponent<WeatherVisuals>();

        visuals.updateWeatherParticles(weather);
    }

    private void setWeatherBasedStorms()
    {
        stormBringer.resetStorms(calendar.getForecastTemp(0), calendar.getForecastWeather(0));
    }

    bool foodOwed = false;

    private IEnumerator Timer (float time) {

        while (true) {
            yield return new WaitForSeconds (time);
            calendar.toNextDay();
            updateTimedEffects();

            if (calendar.getCurrentDay() == 1)
            {
                daychange.value = daychange.minValue;
            }
            if(gracePeriod == 0)
            {
                weatherScript.increaseRandomWeatherChance();
            }
            else
            {
                gracePeriod--;
            }
            
        }

    }

    private IEnumerator DayCycle(float time)
    {
        float oldVal = 0f;
        float newVal = 1.25f;

        float passedTime = 0;

        while (true)
        {
            yield return null;
            passedTime += Time.deltaTime;

            if (passedTime > time / 2) {
                passedTime -= (time / 2);
                float swapVal = oldVal;
                oldVal = newVal;
                newVal = swapVal;
            }

            float t = passedTime / (time / 2);
            float haloVal = Mathf.Lerp(oldVal, newVal, t);
            postProcessing.setHaloAmount(haloVal);
        }
    }

    private void updateTimedEffects()
    {
        generateMonster.SpawnMonsters (calendar.getForecastWeather (0));

        //UIObject.GetComponent<WeatherUI> ().updateTemp (calendar.getForecastTemp (0));
        //UIObject.GetComponent<WeatherUI> ().updateWeatherName (calendar.getForecastWeather (0));

        //print (calendar.getCurrentDay ());
        daychangetext.text = calendar.getCurrentDay().ToString();
        seasonchange.text = (calendar.getCurrentSeason() + 1).ToString();
        daychange.value = calendar.getCurrentDay();

        setWeatherBasedPostProcessing();
        setWeatherBasedParticles();
        setWeatherBasedStorms();
        if(foodOwed){
            
            MetaScript.getFoodSystem().tickDay();
        }
        foodOwed = true;
    }
}
    

  



