using UnityEngine;

public class AdsManager : MonoBehaviour
{
    void OnApplicationPause(bool isPaused)
    {
        IronSource.Agent.onApplicationPause(isPaused);
    }

    public void Start()
    {
        IronSource.Agent.init("1b2e1b5f5", IronSourceAdUnits.REWARDED_VIDEO);
        IronSource.Agent.validateIntegration();
    }

    void OnEnable()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;

        //Add AdInfo Rewarded Video Events
        IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;

    }

    private void SdkInitializationCompletedEvent() { }


    /************* RewardedVideo AdInfo Delegates *************/
    // Indicates that there’s an available ad.
    // The adInfo object includes information about the ad that was loaded successfully
    // This replaces the RewardedVideoAvailabilityChangedEvent(true) event
    void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
    {
    }
    // Indicates that no ads are available to be displayed
    // This replaces the RewardedVideoAvailabilityChangedEvent(false) event
    void RewardedVideoOnAdUnavailable()
    {
    }
    // The Rewarded Video ad view has opened. Your activity will loose focus.
    void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
    {
    }
    // The Rewarded Video ad view is about to be closed. Your activity will regain its focus.
    void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
    {
    }
    // The user completed to watch the video, and should be rewarded.
    // The placement parameter will include the reward data.
    // When using server-to-server callbacks, you may ignore this event and wait for the ironSource server callback.
    void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {
        GameManager.instance.adsMenu.SetActive(false);
        GameManager.instance.isGameOver = false;
        GameManager.instance.isPlayerPaused = false;
        GameManager.instance.isPlayingAudio = false;
        GameManager.instance.lives = 1;
        GameManager.instance.pauseButton.raycastTarget = true;
        GameManager.instance.finished = false;
        GameManager.instance.endTime = 2;
        GameManager.instance.unPaused = true;
        GameManager.instance.cannotPause = false;
        GameManager.instance.showGameplayText.Invoke();
    }
    // The rewarded video ad was failed to show.
    void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
    {
    }
    // Invoked when the video ad was clicked.
    // This callback is not supported by all networks, and we recommend using it only if
    // it’s supported by all networks you included in your build.
    void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {
    }

    public void ShowAd()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
        {
            GameManager.instance.cannotPause = true;
            IronSource.Agent.showRewardedVideo();
        }
        else
        {
            Debug.Log("Ad not available");
        }
    }

}

