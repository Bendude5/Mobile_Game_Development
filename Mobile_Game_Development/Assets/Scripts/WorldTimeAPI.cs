using UnityEngine;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class WorldTimeAPI : MonoBehaviour
{
    public static WorldTimeAPI Instance;

    public string dates;
    public string times;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {

        }
    }


    private void Update()
    {
        //Sets current time
        DateTime currentDateTime = WorldTimeAPI.Instance.GetCurrentDateTime();
    }

    struct TimeData
    {
        public string datetime;
    }

    //Gets time from online
    const string API_URL = "http://worldtimeapi.org/api/ip";

    [HideInInspector] public bool IsTimeLodaed = false;

    private DateTime _currentDateTime = DateTime.Now;

    [Obsolete]
    void Start()
    {
        StartCoroutine(GetRealDateTimeFromAPI());
    }

    public DateTime GetCurrentDateTime()
    {
        return _currentDateTime.AddSeconds(Time.realtimeSinceStartup);
    }

    [Obsolete]
    IEnumerator GetRealDateTimeFromAPI()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(API_URL);
        Debug.Log("getting real datetime...");

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log("Error: " + webRequest.error);
        }

        else
        {
            TimeData timeData = JsonUtility.FromJson<TimeData>(webRequest.downloadHandler.text);

            _currentDateTime = ParseDateTime(timeData.datetime);
            IsTimeLodaed = true;

            Debug.Log("Success.");
        }
    }

    DateTime ParseDateTime(string datetime)
    {
        //0000-00-00 Date
        dates = Regex.Match(datetime, @"^\d{4}-\d{2}-\d{2}").Value;

        //00:00:00 Time
        times = Regex.Match(datetime, @"\d{2}:\d{2}:\d{2}").Value;

        return DateTime.Parse(string.Format("{0} {1}", dates, times));
    }
}