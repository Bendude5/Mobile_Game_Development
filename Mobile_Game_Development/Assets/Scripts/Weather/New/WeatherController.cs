using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;


public class WeatherController : MonoBehaviour
{
    //API key
    private const string API_KEY = "81fd2d142d2de0b2bd75174539558760";
    private const float API_CHECK_MAXTIME = 10 * 60.0f;

    //Snow
    public GameObject snowSystem;
    public bool currentlySnowing = false;

    //Rain
    public GameObject RainSystem;
    public bool currentlyRaining = false;

    //Clouds
    public GameObject CloudSystem;
    public GameObject SunSystem;

    public ParticleSystem Snowing;
    public ParticleSystem Raining;
    public ParticleSystem Cloudy;

    //Current City ID of player
    public string CityId;

    private float apiCheckCountdown = API_CHECK_MAXTIME;

    // Start is called before the first frame update
    void Start()
    {
        CheckWeatherStatus();

        Input.location.Start();

        Input.location.Stop();

    }

    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            CheckWeatherStatus();
            apiCheckCountdown = API_CHECK_MAXTIME;
        }
    }

    public void CheckWeatherStatus()
    {
        Debug.Log(GetWeather().weather[0].main);

        string weather = GetWeather().weather[0].main;

        //If it is snowing or there is sleet, it will activate the snow objects
        if (weather == "Snow" || weather == "Sleet")
        {
            snowSystem.SetActive(true);
            Snowing.Play();
            currentlySnowing = true;

            RainSystem.SetActive(false);
            Raining.Stop();
            currentlyRaining = false;
            CloudSystem.SetActive(false);
            Cloudy.Stop();
            SunSystem.SetActive(false);
        }

        //If it raining, it will activate the rain objects
        else if (weather == "Rain")
        {
            RainSystem.SetActive(true);
            Raining.Play();
            currentlyRaining = true;

            snowSystem.SetActive(false);
            Snowing.Stop();
            currentlyRaining = false;
            CloudSystem.SetActive(false);
            Cloudy.Stop();
            SunSystem.SetActive(false);
        }

        //If it is windy, cloudy, misty or there is fog, it will activate cloud objects
        else if (weather == "Wind" || weather == "Clouds" || weather == "Mist" || weather == "Fog")
        {
            CloudSystem.SetActive(true);
            Cloudy.Play();

            snowSystem.SetActive(false);
            Snowing.Stop();
            currentlySnowing = false;
            RainSystem.SetActive(false);
            Raining.Stop();
            currentlyRaining = false;
            SunSystem.SetActive(false);
        }

        //If there is no weather, then it will deactivate all weather objects
        else
        {
            snowSystem.SetActive(false);
            Snowing.Stop();
            currentlySnowing = false;
            RainSystem.SetActive(false);
            Raining.Stop();
            currentlyRaining = false;
            CloudSystem.SetActive(false);
            Cloudy.Stop();
            SunSystem.SetActive(true);
        }
    }



    private WeatherInfo GetWeather()
    {
        //Gets weather from online using the City ID and the API key
        HttpWebRequest request =
        (HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?id=%7B0%7D&APPID=%7B1%7D",
         CityId, API_KEY));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
        return info;
    }
}

[Serializable]
public class Weather
{
    public int id;
    public string main;
}

[Serializable]
public class WeatherInfo
{
    public int id;
    public string name;
    public List<Weather> weather;
}