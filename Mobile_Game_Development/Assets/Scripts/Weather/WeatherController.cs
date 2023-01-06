//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Net;
//using System;
//using System.IO;
////using Assets;
//using System.Threading.Tasks;


//[Serializable]
//public class Weather
//{
//    public int id;
//    public string main;
//}
//[Serializable]
//public class WeatherInfo
//{
//    public int id;
//    public string name;
//    public List<Weather> weather;
//}

//public class WeatherController : MonoBehaviour
//{
//    private const string API_KEY = "88169749096b61e3b85398905927f53c";
//    private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes
//    public GameObject SnowSystem;
//    public string CityId;
//    private float apiCheckCountdown = API_CHECK_MAXTIME;
//    void Start()
//    {
//        StartCoroutine(GetWeather(CheckSnowStatus));
//    }
//    void Update()
//    {
//        apiCheckCountdown -= Time.deltaTime;
//        if (apiCheckCountdown <= 0)
//        {
//            apiCheckCountdown = API_CHECK_MAXTIME;
//            StartCoroutine(GetWeather(CheckSnowStatus));
//        }
//    }
//    public void CheckSnowStatus(WeatherInfo weatherObj)
//    {
//        bool snowing = weatherObj.weather[0].main.Equals("Snow");
//        if (snowing)
//            SnowSystem.SetActive(true);
//        else
//            SnowSystem.SetActive(false);
//    }
//    private async Task<WeatherInfo> GetWeather()
//    {
//          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", CityId, API_KEY));
//          HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
//          StreamReader reader = new StreamReader(response.GetResponseStream());
//          string jsonResponse = reader.ReadToEnd();
//          WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
//          return info;
//     }

//    IEnumerator GetWeather(Action<WeatherInfo> onSuccess)
//    {
//        using (UnityWebRequest req = UnityWebRequest.Get(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", CityId, API_KEY)))
//        {
//            yield return req.Send();
//            while (!req.isDone)
//                yield return null;
//            byte[] result = req.downloadHandler.data;
//            string weatherJSON = System.Text.Encoding.Default.GetString(result);
//            WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(weatherJSON);
//            onSuccess(info);
//        }
//    }
//}