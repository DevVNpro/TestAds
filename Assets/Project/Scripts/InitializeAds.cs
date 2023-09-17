using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour,IUnityAdsInitializationListener
{
    public string androiGameId;
    public string iosGameId;
    public bool isTestingMode = true;
    string gameId;

    private void Awake()
    {
        InitializeAdsGame();
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads initialized!!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Failed to initialize");
    }

    void InitializeAdsGame(){
#if UNITY_IOS
    gameId = iosGameId;
#elif UNITY_ANDROID
    gameId = androiGameId;
#elif UNITY_EDITOR
    gameId = androidGameId; 
#endif
    if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTestingMode, this);

        }



    }
}
