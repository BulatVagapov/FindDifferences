using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;

public class AppodealManager : MonoBehaviour, IInterstitialAdListener
{
    public static string appKey = "";

    [SerializeField] private bool testingMode;
    [SerializeField] private TestAppodeal testAppodeal;
    
    void Start()
    {
        Initialize();
    }

    public void ShowInterstitialAds()
    {
        if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
        {
            Appodeal.show(Appodeal.INTERSTITIAL);
        }

        testAppodeal.OnStartAdv();
    }
    
    private void Initialize()
    {
        Appodeal.setTesting(testingMode);

        Appodeal.muteVideosIfCallsMuted(true);

        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL);
        Appodeal.setInterstitialCallbacks(this);
    }

    public void onInterstitialLoaded(bool isPrecache)
    {
        print("Int loaded");
    }

    public void onInterstitialFailedToLoad()
    {
        print("Int loading filed");
    }

    public void onInterstitialShowFailed()
    {
        print("Int show filed");
    }

    public void onInterstitialShown()
    {
        print("Int shown");
    }

    public void onInterstitialClosed()
    {
        print("Int closed");
    }

    public void onInterstitialClicked()
    {
        print("Int clicked");
    }

    public void onInterstitialExpired()
    {
        print("Int expired");
    }


}
