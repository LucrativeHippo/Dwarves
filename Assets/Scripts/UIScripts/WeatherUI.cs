using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeatherUI : MonoBehaviour {

    [SerializeField] private Text temperatureText;
    [SerializeField] private Text weatherNameText;
   
    public void updateTemp (float temp) {
        double aTemp = System.Math.Round (temp, 0);
        temperatureText.text = "" + aTemp;
    }

    public void updateWeatherName (Weather.weatherTypes type) {
        weatherNameText.text = type.ToString ();
      
    }
}
