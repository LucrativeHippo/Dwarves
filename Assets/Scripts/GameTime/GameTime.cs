using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTime : MonoBehaviour {

    public float dayTime = 300.0f;
    private Calendar calendar;
    private GameObject calendarObject;
    private Weather weatherScript;
    public Slider daychange;
    public Text daychangetext;
    public Text seasonchange;
  //  private GenerateMonster generateMonster;
    private GameObject UIObject;

    void Start () {
        UIObject = GameObject.Find ("UIController");

        GameObject temp = GameObject.Find ("monster_generator");
        weatherScript = gameObject.GetComponent<Weather> ();
        calendar = gameObject.GetComponent<Calendar> ();
        //generateMonster = temp.GetComponent<GenerateMonster> ();
        StartCoroutine (Timer (dayTime));
      
    }
    private void Update()
    {
       
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
        }
    }
}
