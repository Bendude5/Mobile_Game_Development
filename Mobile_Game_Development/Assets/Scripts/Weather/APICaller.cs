//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Networking;
//using TMPro;
//using SimpleJSON;

//public class APICaller : MonoBehaviour
//{

//    bool routine;
//    [SerializeField] string url, apiKey;

//    [SerializeField] TextMeshProUGUI text;

//    [SerializeField] RawImage image;

//    [SerializeField] TMP_InputField input;

//    [SerializeField] int currentAPIIndex;

//    private void Start()
//    {
//        Input.location.Start();
//    }

//    private void OnMouseDown()
//    {
//        RequestAPI();
//    }

//    public void RequestAPI()
//    {
//        if (!routine) StartCoroutine(WaitForServerResponse());

//    }

//    IEnumerator WaitForServerResponse()
//    {

//        routine = true;
//        UnityWebRequest req = UnityWebRequest.Get(url);
//        if (currentAPIIndex == 1)
//        {
//            string weatherURL = url + apiKey + "&q=lat=" + (int)Input.location.lastData.latitude + "&lon=" + (int)Input.location.lastData.longitude + "&aqi=no";
//            print(weatherURL);
//            req = UnityWebRequest.Get(weatherURL);
//        }
//        else req = UnityWebRequest.Get(url);

//        string[] pages = req.url.Split('/');
//        int page = pages.Length - 1;
//        yield return req.SendWebRequest();

//        switch (req.result)
//        {

//            case UnityWebRequest.Result.ConnectionError:
//                break;
//            case UnityWebRequest.Result.DataProcessingError:
//                Debug.LogError(pages[page] + ": Error: " + req.error);
//                break;
//            case UnityWebRequest.Result.ProtocolError:
//                Debug.LogError(pages[page] + ": HTTP Error: " + req.error + " " + name);
//                break;
//            case UnityWebRequest.Result.Success:

//                switch (currentAPIIndex)
//                {
//                    case 0:
//                        text.text = req.downloadHandler.text;
//                        break;
//                    case 1:
                 
//                        JSONNode info = JSON.Parse(req.downloadHandler.text);
//                        text.text = info["current"]["condition"]["text"] + " " +info["current"]["temp_c"];

//                        break;
//                    case 2:
//                        string pokemon = url + input.text.ToString();
//                        UnityWebRequest pokeReq = UnityWebRequest.Get(pokemon);
//                        yield return pokeReq.SendWebRequest();
//                        JSONNode pokeInfo = JSON.Parse(pokeReq.downloadHandler.text);

//                        string pokemonSpriteURL = pokeInfo["sprites"]["front_default"];
//                        UnityWebRequest spriteRequest = UnityWebRequestTexture.GetTexture(pokemonSpriteURL);
//                        yield return spriteRequest.SendWebRequest();

//                        image.texture = ((DownloadHandlerTexture)spriteRequest.downloadHandler).texture;

//                        break;

//                }
//                break;

//        }


//        routine = false;

//    }

//}