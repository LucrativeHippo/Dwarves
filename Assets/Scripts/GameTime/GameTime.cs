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
    //  private GenerateMonster generateMonster;
    private GameObject UIObject;
    private UseCustomImageEffect postProcessing;



    void Start()
    {
        UIObject = GameObject.Find("UIController");

        GameObject temp = GameObject.Find("monster_generator");
        weatherScript = gameObject.GetComponent<Weather>();
        calendar = gameObject.GetComponent<Calendar>();
        //generateMonster = temp.GetComponent<GenerateMonster> ();

        postProcessing = GameObject.FindObjectOfType<UseCustomImageEffect>();
        StartCoroutine (Timer (dayTime));

        if (postProcessing != null)
        {
            postProcessing.setDoHalo(true);
            StartCoroutine(DayCycle(dayTime));
        }
       
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

    private IEnumerator Timer (float time) {
        while (true) {
            yield return new WaitForSeconds (time);
            calendar.toNextDay ();
            //generateMonster.SpawnMonsters (calendar.getForecastWeather (0));

            UIObject.GetComponent<WeatherUI> ().updateTemp (calendar.getForecastTemp (0));
            UIObject.GetComponent<WeatherUI> ().updateWeatherName (calendar.getForecastWeather (0));

            //print (calendar.getCurrentDay ());
            //daychangetext.text=calendar.getCurrentDay().ToString();
            //seasonchange.text = calendar.getCurrentSeason().ToString();
            //daychange.value = calendar.getCurrentDay();

            Debug.Log(calendar.getCurrentDay());

            setWeatherBasedPostProcessing();
            setWeatherBasedParticles();

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
}
    

  



