using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4996703");
        Advertisement.AddListener(this);
        showBanner();
    }

    public void playAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void playRewardedAd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded ad is not ready!");
        }
    }

    public void showBanner()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    public void hideBanner()
    {
        Advertisement.Banner.Hide();
    }


    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        showBanner();
    }


    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ADS ARE READY!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR!: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("VIDEO STARTED");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("PLAYER SHOULD BE REWARDED!");
        }
    }
}