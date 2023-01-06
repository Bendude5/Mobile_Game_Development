using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;


public class WeatherController : MonoBehaviour
{

    private const string API_KEY = "81fd2d142d2de0b2bd75174539558760";
    private const float API_CHECK_MAXTIME = 10 * 60.0f;

    public GameObject snowSystem;
    public bool currentlySnowing = false;

    public GameObject RainSystem;
    public bool currentlyRaining = false;

    public GameObject CloudSystem;
    public GameObject SunSystem;

    public ParticleSystem Snowing;
    public ParticleSystem Raining;
    public ParticleSystem Cloudy;

    public int wasSunny = 0;

    public string CityId;

    private float apiCheckCountdown = API_CHECK_MAXTIME;

    // Start is called before the first frame update
    void Start()
    {
        CheckWeatherStatus();

        //// Check if the user has location service enabled.
        //if (!Input.location.isEnabledByUser)
        //    yield break;

        // Starts the location service.
        Input.location.Start();

        Input.location.Stop();

    }

        // Update is called once per frame
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
            if (wasSunny > 0)
            {
                wasSunny -= 1;
            }

            if (wasSunny == 1)
            {
                //pw
            }
        }

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

            if (wasSunny > 0)
            {
                wasSunny -= 1;
            }

            if (wasSunny == 1)
            {
                //pm
            }
        }

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

            if (wasSunny > 0)
            {
                wasSunny -= 1;
            }

            if (wasSunny == 1)
            {
                //pm
            }
        }

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

            //pm
            wasSunny = 2;
        }
    }



    private WeatherInfo GetWeather()
    {
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