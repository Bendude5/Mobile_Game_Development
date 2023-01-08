//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Networking;
//using TMPro;
//using SimpleJSON;

//public class GetMyWeather : MonoBehaviour
//{

//    public UILabel myWeatherLabel;
//    public UITexture myWeatherCondition;

//    public string currentIP;
//    public string currentCountry;
//    public string currentCity;

//    //retrieved from weather API
//    public string retrievedCountry;
//    public string retrievedCity;
//    public int conditionID;
//    public string conditionName;
//    public string conditionImage;

//    void Start()
//    {
//        StartCoroutine(SendRequest());
//    }

//    IEnumerator SendRequest()
//    {
//        //get the players IP, City, Country
//        Network.Connect("http://google.com");
//        currentIP = Network.player.externalIP;
//        Network.Disconnect();

//        WWW cityRequest = new WWW("http://www.geoplugin.net/json.gp?ip=" + currentIP); //get our location info
//        yield return cityRequest;

//        if (cityRequest.error == null || cityRequest.error == "")
//        {
//            var N = JSON.Parse(cityRequest.text);
//            currentCity = N["geoplugin_city"].Value;
//            currentCountry = N["geoplugin_countryName"].Value;
//        }

//        else
//        {
//            Debug.Log("WWW error: " + cityRequest.error);
//        }

//        //get the current weather
//        WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?q=" + currentCity); //get our weather
//        yield return request;

//        if (request.error == null || request.error == "")
//        {
//            var N = JSON.Parse(request.text);

//            retrievedCountry = N["sys"]["country"].Value; //get the country
//            retrievedCity = N["name"].Value; //get the city

//            string temp = N["main"]["temp"].Value; //get the temperature
//            float tempTemp; //variable to hold the parsed temperature
//            float.TryParse(temp, out tempTemp); //parse the temperature
//            float finalTemp = Mathf.Round((tempTemp - 273.0f) * 10) / 10; //holds the actual converted temperature

//            int.TryParse(N["weather"][0]["id"].Value, out conditionID); //get the current condition ID
//            //conditionName = N["weather"][0]["main"].Value; //get the current condition Name
//            conditionName = N["weather"][0]["description"].Value; //get the current condition Description
//            conditionImage = N["weather"][0]["icon"].Value; //get the current condition Image

//            //put all the retrieved stuff in the label
//            myWeatherLabel.text =
//                "Country: " + retrievedCountry
//                + "\nCity: " + retrievedCity
//                + "\nTemperature: " + finalTemp + " C"
//                + "\nCurrent Condition: " + conditionName
//                + "\nCondition Code: " + conditionID;
//        }
//        else
//        {
//            Debug.Log("WWW error: " + request.error);
//        }

//        //get our weather image
//        WWW conditionRequest = new WWW("http://openweathermap.org/img/w/" + conditionImage + ".png");
//        yield return conditionRequest;

//        if (conditionRequest.error == null || conditionRequest.error == "")
//        {
//            //create the material, put in the downloaded texture and make it visible
//            var texture = conditionRequest.texture;
//            Shader shader = Shader.Find("Unlit/Transparent Colored");
//            if (shader != null)
//            {
//                var material = new Material(shader);
//                material.mainTexture = texture;
//                myWeatherCondition.material = material;
//                myWeatherCondition.color = Color.white;
//                myWeatherCondition.MakePixelPerfect();
//            }
//        }
//        else
//        {
//            Debug.Log("WWW error: " + conditionRequest.error);
//        }
//    }
//}