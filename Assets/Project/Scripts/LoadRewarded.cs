using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class LoadRewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;
    private void Awake()
    {
#if UNITY_IOS
    adUnitId =  iosAdUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId; 
#endif
    }
    public void LoadAd()
    {
        Debug.Log("Loading Rewarded");
        Advertisement.Load(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals(adUnitId))
        {

            Debug.Log("Rewarded Loaded");
            ShowAd();

        }

    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("placementId:" + placementId + ",error:" + error + ",Message:" + message);
    }


    public void ShowAd()
    {
        Advertisement.Show(adUnitId, this);

    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Rewarded Clicked!");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if(placementId.Equals(adUnitId) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
        {
            Debug.Log("Rewarded show complete");

        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Rewarded show Failure");

    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Rewarded Show Start");
    }
}
