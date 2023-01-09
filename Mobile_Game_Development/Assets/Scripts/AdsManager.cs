using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    // Start is called before the first frame update

    public GameObject player;

    void Start()
    {
        Advertisement.Initialize("4996703");
        Advertisement.AddListener(this);
        showBanner();
    }

    public void RemoveListener()
    {

    }

    void Update()
    {

    }

    //Plays normal advert
    public void playAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
            GameObject.Find("Player").GetComponent<Basic_Movement>().canPlayAd = false;
        }
    }

    //Plays reward advert
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

    //Shows banner
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

    //Hides banner
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

    //When reward ad is done, it will give reward
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Time.timeScale = 1;
            player.GetComponent<Basic_Movement>().gameOver.SetActive(false);
            player.GetComponent<Basic_Movement>().anim.SetInteger("Anim_Number", 1);
            player.GetComponent<Basic_Movement>().currentHealth = 100;
            player.GetComponent<Basic_Movement>().canRestart = false;
            Debug.Log("PLAYER SHOULD BE REWARDED!");
        }
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}