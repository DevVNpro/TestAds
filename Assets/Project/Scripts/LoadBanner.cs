using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class LoadBanner : MonoBehaviour
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;    
    void Start()
    {
#if UNITY_IOS
    adUnitId = androidAdUnitId;
#elif UNITY_ANDROID
        adUnitId = iosAdUnitId;
#endif
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void LoadBannerGame() {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerLoadError
        };
        Advertisement.Banner.Load(adUnitId, options);
     }
    void OnBannerLoaded()
    {
        Debug.Log("Banner Loaded!!");
        showBannerAd();
    }
    void OnBannerLoadError(string error)
    {
        Debug.Log("Banner Error!!");
    }
    public void showBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = OnBannerShow,
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden
        };
        Advertisement.Banner.Show(adUnitId, options);

    }
    void OnBannerShow()
    {

    }
    void OnBannerClicked()
    {


    }
    void OnBannerHidden()
    {


    }
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

}
