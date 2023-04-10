using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;
    public bool showINT;
    float intersitialTimer = 45f;
    Coroutine intLoopCoroutine;
    Action onRVSuccess;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;

    }

    private void Start()
    {
        if (IsNoAdsPurchased()) return;
        this.CallWithDelay(() =>
        {
            StopAndStartIntLoop();

        }, 45);

    }

    public void InitApplovin()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) => {
            // AppLovin SDK is initialized, start loading ads
            InitilizeINTAD();
        };

        MaxSdk.SetSdkKey("w355X7THU65cGpUGMP72a_JGZgTZJ2_hBidRLo1WF6GV1TVE56f_v1B0wzMzK3RRaQTJgTmcMsNxJ9BT84z9WZ");
        MaxSdk.InitializeSdk();
    }

    #region RV
    string rvID = "b62d82dcf3ad88d7";
    int rvRetryAttempts;

    public void InitializeRewardedAds()
    {
        // Attach callback
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        // Load the first rewarded ad
        LoadRewardedAd();
    }

    private void LoadRewardedAd()
    {
        MaxSdk.LoadRewardedAd(rvID);
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is ready for you to show. MaxSdk.IsRewardedAdReady(adUnitId) now returns 'true'.

        // Reset retry attempt
        rvRetryAttempts = 0;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Rewarded ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds).

        rvRetryAttempts++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));
        RVFailed();
        Invoke("LoadRewardedAd", (float)retryDelay);
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
        LoadRewardedAd();
    }


    private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        RvFinished();
        // Rewarded ad is hidden. Pre-load the next ad
        LoadRewardedAd();
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        // The rewarded ad displayed and the user should receive the reward.
    }


    public void ShowRV(Action _onRVSuccess)
    {
        if (Application.isEditor)
        {
            _onRVSuccess?.Invoke();
            return;
        }
        if (MaxSdk.IsRewardedAdReady(rvID))
        {
            MaxSdk.ShowRewardedAd(rvID);
        }
        onRVSuccess = _onRVSuccess;

        AudioManager.instnace.SetAudioMute(true);

        GeneralManager.PauseTheGame();
        NotificationCanvas.instance.loadingPanel.ShowScale(true);
    }



    void RvFinished()
    {
        RVADClosed();
        NotificationCanvas.instance.loadingPanel.ShowScale(false);
        StopAndStartIntLoop();
    }

    void RVFailed()
    {
        RVADClosed();
        LoadRewardedAd();
        MessagePanel.instance.ShowMessage("Video Failed");
    }


    void RVADClosed()
    {
        GeneralManager.ResumeTheGame();
        AudioManager.instnace.SetAudioMute(false);
        NotificationCanvas.instance.loadingPanel.ShowScale(false);
    }

    #endregion

    #region Int

    string intID = "6e3659103a6baba7";
    int retryAttempt;

    public void InitilizeINTAD()
    {
        // Attach callback
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;

        // Load the first interstitial
        LoadInterstitial();
    }


    private void LoadInterstitial()
    {
        MaxSdk.LoadInterstitial(intID);
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        retryAttempt = 0;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        retryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));

        Invoke("LoadInterstitial", (float)retryDelay);
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
        LoadInterstitial();
    }
    #endregion



    void ShowInt()
    {
        if (MaxSdk.IsInterstitialReady(intID))
        {
            MaxSdk.ShowInterstitial(intID);
        }
    }


    public void ShowBanner()
    {
        if (IsNoAdsPurchased()) return;
    }


    IEnumerator IntersitialLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(intersitialTimer);
            ShowInt();
        }

    }

    public void StopAndStartIntLoop()
    {
        if (!showINT) return;
        if (intLoopCoroutine != null)
        {
            StopCoroutine(intLoopCoroutine);
        }
        if (IsNoAdsPurchased()) return;
        intLoopCoroutine = StartCoroutine(IntersitialLoop());

    }

    public void DisableAllAds()
    {
        if(intLoopCoroutine != null)
        {
            StopCoroutine(intLoopCoroutine);
        }
    }

    public bool IsNoAdsPurchased()
    {
        return PlayerPrefs.GetInt("NoAds") == 1;
    }

    //

   
}