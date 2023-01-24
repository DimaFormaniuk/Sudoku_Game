using System;

namespace CodeBase.Infrastructure.Services.Ads
{
    public interface IAdsService : IService
    {
        void Init();
        bool HasLoadedRewarded();
        void ShowRewarded(Action<AdsResultType> onAdResult = null);
        void RewardedLoaded(Action loaded);
        bool HasLoadedInterstitial();
        void ShowInterstitial(Action<AdsResultType> onAdResult = null);
        void InterstitialLoaded(Action loaded);
    }
}